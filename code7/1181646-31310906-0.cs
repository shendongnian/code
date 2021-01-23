    using System;
    
    public class Program
    {
        static void Main(string[] args)
        {
            var area = AreaofSquare(5.0);
        }
    
        public static double AreaofSquare(double side)
        {
            double area;
            area = Math.Pow(side, 2);
            return area;
        }
    }
