using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace domZad5
{
    enum BankAcc
    {
        Savings = 01,
        Current = 10,
    }
    class AccountBank7dot1
    {
        private int number;
        private double balance;
        private BankAcc typeAccount;
        public int Number
        { 
          get { return number; }     //возвращаем значение свойства
          set { number = value;}     //устанавливаем новое значение свойства
        }
        public double Balance
        {
          get;                       // присваиваем автосвойству значение по умолчанию
          set; 
        } = 3400.5245;
        public BankAcc TypeAccount
        {
            get => typeAccount;
            set => typeAccount = value; // используем сокращённую запись свойств
        }
    }
    class AccountBank7dot2
    {
        private static int number;
        private double balance;
        private BankAcc typeAccount;
        private static HashSet<int> lastRandomnumber = new HashSet<int>(0);
        public static int newNumber()
        {
            Random a = new Random();
            number = a.Next(0, int.MaxValue - 1);
            if (!lastRandomnumber.Contains(number))
                number++;
            return number;
        }
        public int Number
        {
            get;      //возвращаем значение свойства
            set;      //устанавливаем новое значение свойства
        }
        public double Balance
        {
            get;                       // присваиваем автосвойству значение по умолчанию
            set;
        } = 3400.5245;
        public BankAcc TypeAccount
        {
            get => typeAccount;
            set => typeAccount = value; // используем сокращённую запись свойств
        }
        public AccountBank7dot2(int Number,double Balance, BankAcc TypeAccount) 
        {
            number = Number;
            balance = Balance;
            typeAccount = TypeAccount;
        }
        public void Vivod(int newID) => Console.WriteLine($"Банковский счёт:\n Тип: {TypeAccount}\n Номер счёта: {newID}\n Баланс счёта: {Balance}\n");
    }
    class AccountBank7dot3
    {
        private static int number;
        private double balance;
        private BankAcc typeAccount;
        private static HashSet<int> lastRandomnumber = new HashSet<int>(0);
        public static int newNumber()
        {
            Random a = new Random();
            number = a.Next(0, int.MaxValue - 1);
            if (!lastRandomnumber.Contains(number))
                number++;
            return number;
        }
        public int Number
        {
            get => number;              //возвращаем значение свойства
            set => number = value;      //устанавливаем новое значение свойства
        }
        public double Balance
        {
            get;                       // присваиваем автосвойству значение по умолчанию
            set;
        }
        public BankAcc TypeAccount
        {
            get => typeAccount;
            set => typeAccount = value; // используем сокращённую запись свойств
        }
        public AccountBank7dot3(int Number, double Balance, BankAcc TypeAccount)
        {
            number = Number;
            balance = Balance;
            typeAccount = TypeAccount;
        }
        public void Vivod(int newID) => Console.WriteLine($"Банковский счёт:\n Тип: {TypeAccount}\n Номер счёта: {newID}\n Баланс счёта: {Balance}\n");
        public void Adder(ref double balance)
        {
            repeat:
            Console.WriteLine("Введите сумму, которую хотите положить на счёт");
            double b = double.Parse(Console.ReadLine());
            if (b > 0)
            {
                balance += b;
                Console.WriteLine($"Счёт пополнен. Текущий баланс: {balance}");
            }
            else
            {
                Console.WriteLine("Неверное число. Повторите операцию.");
                goto repeat;
            }
        }
        public void Lower(ref double balance)
        {
            if (balance > 0)
            {
                repeat:
                Console.WriteLine("Введите сумму, которую хотите снять с счёта");
                double b = double.Parse(Console.ReadLine());
                if (b > 0 & balance>b)
                {
                    balance -= b;
                    Console.WriteLine($"Деньги сняты, текущий баланс: {balance}");
                }
                else
                {
                    Console.WriteLine($"Операция невозможна, текущий баланс: {balance}\nПовторите операцию.");
                    goto repeat;
                }
            }
            else
            {
                Console.WriteLine("У вас какой-то неправильный баланс");
            }
        }
    }
    class Building
    {
        public Building() { }
        byte dom { get; set; }
        byte height { get; set; }
        byte floors { get; set; }
        short number_of_flats { get; set; }
        byte porch { get; set; }
        public Building(byte dom,byte height, byte floors, short number_of_flats, byte porch)
        {
            this.dom = dom;
            this.height = height;
            this.floors = floors;
            this.number_of_flats = number_of_flats;
            this.porch = porch;
        }
        private static HashSet<byte> lastrandomdom = new HashSet<byte>(0);
        public byte Newdom()
        {
            Random a = new Random();
            dom = (byte)a.Next(1, byte.MaxValue);
            if (!lastrandomdom.Contains(dom))
            {
                dom++;
            }
            return dom;    
        }
        public void HeightOfFloor()
        {
            Console.WriteLine($"Высота этажа: {(double)height / (double)floors}");
        }
        public void FlatCountPerEntrance()
        {
            Console.WriteLine($"Квартир в подъезде: {number_of_flats / porch}");
        }
        public void FlatCountPerFloor()
        {
            Console.WriteLine($"Квартир на этаже: {number_of_flats / porch / floors}");
        }
        public void Print() => Console.WriteLine($"Номер здания: {dom}," +
            $"высота здания: {height}, этажность: {floors}, количество квартир: {number_of_flats}," +
            $"количество подъездов: {porch}");
    }
    class Program
    {
        static void Zad7dot1()
        {
            AccountBank7dot1 koshelek = new AccountBank7dot1();
            koshelek.Number = 00228;
            koshelek.Balance = 5600.0;
            koshelek.TypeAccount = (BankAcc)10;
            Console.WriteLine($"Банковский счёт:\n Тип:{koshelek.TypeAccount}\n Номер счёта:{koshelek.Number}\n Баланс счёта: {koshelek.Balance}\n");
        }
        static void Zad7dot2()
        {
            int newID = AccountBank7dot2.newNumber();
            AccountBank7dot2 koshelek = new AccountBank7dot2(newID, 45674.3456, (BankAcc)01);
            koshelek.Vivod(newID);
        }
        static void Zad7dot3()
        {
            int newID = AccountBank7dot3.newNumber();
            AccountBank7dot3 koshelek = new AccountBank7dot3(newID, 56, (BankAcc)10);
            koshelek.Number = 00228;
            koshelek.Balance = 5600.0;
            koshelek.TypeAccount = (BankAcc)10;
            double tekushb = koshelek.Balance;
            koshelek.Lower(ref tekushb);
        }
        static void DomZad7dot1()
        {
            Building zdanie = new Building(100, 100, 20, 400, 5);
            zdanie.Print();
            zdanie.HeightOfFloor();
            zdanie.FlatCountPerFloor();
            zdanie.FlatCountPerEntrance();
            Console.ReadKey();
            Console.Clear();
            byte newnumber = zdanie.Newdom();
            Building zdanie1 = new Building(newnumber, 200, 50, 1000, 5);
            zdanie1.Print();
            zdanie1.HeightOfFloor();
            zdanie1.FlatCountPerFloor();
            zdanie1.FlatCountPerEntrance();
        }
        static void Main(string[] args)
        {
            DomZad7dot1();
        }
    }
}
