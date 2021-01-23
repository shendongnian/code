    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Elevator
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                int p = int.Parse(Console.ReadLine());
    
                int elevatorTrips = 0;
                elevatorTrips = Math.Ceiling(n / p);
    
                Console.WriteLine(elevatorTrips);
            }
        }
    }
