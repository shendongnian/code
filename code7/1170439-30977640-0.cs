    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void doWork()
            {
                Point origin = new Point(0, 0);
                Point bottomRight = new Point(1366, 768);
    
                double distance = origin.DistanceTo(bottomRight);
                
                Console.WriteLine("Distance is: {0}", distance);
                //Console.WriteLine("Number of Point objects: {0}", Point.ObjectCount());
                Console.ReadLine();
            }
    
            static void Main(string[] args)
            {
                try
                {
                    doWork();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    
        public static class MyExtensions
        {
            public static double DistanceTo(this Point pointA, Point pointB)
            {
                double dX = pointA.X - pointB.X;
                double dY = pointA.Y - pointB.Y;
    
                double distance = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
                return distance;
            }
        } 
    }
