/*
 * Рычков В.А. ИЭ-65-18
 * Вариант 15.
 * Составить описание класса для вектора, заданного координатами его концов в трехмерном пространстве. 
 * Обеспечить операции сложения и вычитания векторов с получением нового вектора (суммы или разности). 
 * Написать программу, демонстрирующую все разработанные элементы класса.
 * Создать дочерний класс, обеспечивающий операции вычисления скалярного произведения двух векторов, длины вектора и косинуса угла между векторами.
 */

using System; //использовать библиотеку "System" (там класс "Console")

namespace ConsoleAppClassV2
{
    public class Vector
    {
        //поля класса - координаты точки
        protected double X { get; }
        protected double Y { get; }
        protected double Z { get; }
        
        //конструктор объектов класса "Вектор" с тремя параметрами
        public Vector(double x, double y, double z) 
        {
            X = x;
            Y = y;
            Z = z;
        }
        // перегрузка опрераторов для класса "Вектор" (сложение и вычитание векторов)
        public static Vector operator +(Vector l, Vector r)
        {
            return new Vector(l.X + r.X, l.Y + r.Y, l.Z + r.Z);
        }
        
        public static Vector operator -(Vector l, Vector r)
        {
            return new Vector(l.X - r.X, l.Y - r.Y, l.Z - r.Z);
        }
        
        //переопределённый метод родительского (Object) класса
        public override string ToString()
        {
            return "{" + X + ", " + Y + ", " + Z + "}";
        }
    }
    // наследник класса "Вектор" 
    public class SecondVector : Vector
    {
        // конструктор класса, с помощью ключевого слова base обращаемся к базовому классу
        public SecondVector(double x, double y, double z) : base(x, y, z) { }
        
        // метод для нахождения длины вектора
        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }
        
        // перегрузка оператора *, для вычисления скалярного произведения двух векторов
        public static double operator *(SecondVector l, SecondVector r)
        {
            return (l.X * r.X + l.Y * r.Y + l.Z * r.Z);
        }
        
        // метод для нахожения косинуса угла между векторами
        public static double Cos(SecondVector l, SecondVector r)
        {
            return (l * r) / (l.GetLength() * r.GetLength());
        }
    }
    
    // основной класс программы 
    public static class Program
    {
        static void Main(string[] args)
        {
            // смена цвета в консоли
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            // переменные класса (для вектора и меню)
            int p;
            double x1 = 0, x2 = 0, y1 = 0, y2 = 0, z1 = 0, z2 = 0;
            // ввод первого вектора с консоли с проверкой на введенное значение
            Console.WriteLine("Первый вектор.\r\n Введите координаты.");
            x1 = Input("x = ");
            y1 = Input("y = ");
            z1 = Input("z = ");
            // ввод второго вектора с консоли с проверкой на введенное значение
            Console.WriteLine("\r\nВторой вектор.\r\n Введите координаты.");
            x2 = Input("x = ");
            y2 = Input("y = ");
            z2 = Input("z = ");

            Console.Clear(); // отчиска консоли
            
            // вывод на экран введеных векторов
            Vector vector1 = new Vector(x1, y1, z1);
            Console.WriteLine("Вектор 1: " + vector1);

            Vector vector2 = new Vector(x2, y2, z2);
            Console.WriteLine("Вектор 2: " + vector2);
            
            // меню
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Сумма векторов");
            Console.WriteLine("2. Вычитание векторов");
            Console.WriteLine("3. Вычисление скалярного произведения двух векторов");
            Console.WriteLine("4. Косинус угла между векторами");
            Console.WriteLine("5. Длина вектора 1");
            Console.WriteLine("6. Длина вектора 2");
            Console.WriteLine("Нажмите любую другую кнопку для выхода");
            Console.Write("\nВыберите: ");
            do // исполнять пока вводятся разрешенные значение меню
            {
                p = int.Parse(Console.ReadLine()); // выбор пункта
                switch (p) // оператор выбора
                {
                    case 1: // вывод суммы векторов с созданием нового вектора
                        Vector vSum = vector1 + vector2;
                        Console.WriteLine("Сумма: " + vSum);
                        Console.Write("\nВыберите: ");
                        break;
                    case 2: // вывод разности векторов
                        Vector v4 = vector1 - vector2;
                        Console.WriteLine("Разность: " + v4);
                        Console.Write("\nВыберите: ");
                        break;
                    case 3: // вывод скалярного произведения векторов 
                        SecondVector scar = new SecondVector(x1, y1, z1);
                        SecondVector scar2 = new SecondVector(x2, y2, z2);
                        double m = scar * scar2;
                        Console.WriteLine("Скалярное произведение: " + m);
                        Console.Write("\nВыберите: ");
                        break;
                    case 4: // вывод косинуса угла между векторами
                        SecondVector cos = new SecondVector(x1, y1, z1);
                        SecondVector cos2 = new SecondVector(x2, y2, z2);
                        double c = SecondVector.Cos(cos, cos2);
                        Console.WriteLine("Косинус: " + c);
                        Console.Write("\nВыберите: ");
                        break;
                    case 5: // вывод длины вектора 1
                        SecondVector length = new SecondVector(x1, y1, z1);
                        Console.WriteLine("Длина первого вектора: " + length.GetLength());
                        Console.Write("\nВыберите: ");
                        break;
                    case 6: // вывод длины вектора 2
                        SecondVector length2 = new SecondVector(x2, y2, z2);
                        Console.WriteLine("Длина второго вектора: " + length2.GetLength());
                        Console.Write("\nВыберите: ");
                        break;
                    default: // если введено неверное значение, вывод собщения
                        Console.WriteLine("Вы ввели неверный пункт меню");
                        break;
                }
            } while (p >= 1 && p <= 6);
        }
        
        // Метод для ввода значений с клавиатуры.
        // Введённое число типа double.
        private static double Input(String message)
        {
            bool incorrect = true;
            double res = 0;
            while (incorrect)
            {
                try
                {
                    Console.Write(message);
                    res = Double.Parse(Console.ReadLine());
                    incorrect = false;
                }
                catch (FormatException)
                {
                    Console.Write(" Введите число!\r\n");
                }
            }
            return res;
        }
    }
}