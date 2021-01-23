    using System;
    using System.Windows;
    
    namespace Vectors
    {
       
        class Program
        {
            
            static void Main(string[] args)
            {
                // Define Points
                Point Pa = new Point(5.0,1.0);
                Point Pb = new Point(10.0,3.0);
                Point Pc = new Point(7.0,10.0);
                Point Pd = new Point(1.0,3.0);
                Vector V1 = Pa - Pb;
                Vector V2 = Pc - Pd;
    
                Vector V = new Vector(1, 0);
    
                double Phi1 = Math.Atan2(V1.Y, V1.X)*180/Math.PI;
                double Phi2 = Math.Atan2(V2.Y, V2.X)*180/Math.PI;
    
                // Check for -ve angle and take 180 degree complement.
                Phi1 = (Phi1 >= 0) ? Phi1 : 180 + Phi1;
                Phi2 = (Phi2 >= 0) ? Phi2 : 180 + Phi2;
               
                if(Phi1<=Phi2)
                {
                    Console.WriteLine("Vector V1 has a least angle");
                }
                else
                {
                    Console.WriteLine("Vector V2 has a least angle");
                }
                Console.ReadLine();
            }
        }
    }
