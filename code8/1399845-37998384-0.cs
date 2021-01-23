    using System;
    class Circle
    {
        public static double GetCircumference(double radius)
        {
            return 2 * Math.PI * radius;
        }
        static void Main()
        // Circumference of a circle: C=2πr
        {
            Console.WriteLine("What is the radius of your circle: ");
            Console.WriteLine("The Circumference of your circle is: " + GetCircumference(Double.Parse(Console.ReadLine())).ToString());
            Console.ReadKey();
        }
    }
