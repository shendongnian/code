    using System;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("Choose 1, 2, 3 or X to exit.");
    
                    // read input
                    var s = Console.ReadLine();
    
                    // shall we exit ?
                    if (s != null && s.Trim().Equals("X", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Bye bye !");
                        break;
                    }
    
                    // user picked an activity
                    int result;
                    if (!int.TryParse(s, out result)) continue; // failed to read input
    
    
                    // at this point, do something interesting
                    Console.WriteLine("You selected : " + result);
                }
            }
        }
    }
