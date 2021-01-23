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
		
		        var elevatorTrips = Math.Ceiling((double)n / p);
		
		        Console.WriteLine(elevatorTrips);
            }
        }
    }
