    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace Testing
    {
        class Program
        {
            private static readonly int Target = 1234567890;
            private static readonly List<int> Parts = new List<int> { 4, 7, 18, 32, 57, 68 };
     
            static void Main(string[] args)
            {
                Parts.RemoveAll(x => x > Target);
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Console.WriteLine(Solve(Target, Parts));
                stopWatch.Stop();
    
                Console.WriteLine("Calculation took {0}", stopWatch.Elapsed);
                Console.ReadLine();
            }
    
            private static bool Solve(int target, List<int> parts)
            {
                if (parts.Count == 0) return false;
    
                var currentDivisor = parts.First();
                var quotient = target/currentDivisor;
                var modulus = target%currentDivisor;
    
                if (modulus == 0)
                {
                    Console.WriteLine("{0} X {1}", quotient, currentDivisor);
                    return true;
                }
    
                if (quotient == 0) return false;
    
                while (!Solve(target - currentDivisor*quotient, parts.Skip(1).ToList()))
                {
                    quotient--;
                    if (quotient != 0) continue;
    
                    if (parts.Skip(1).ToList().Count > 0)
                        return Solve(target, parts.Skip(1).ToList());
    
                    return false;
                }
    
                Console.WriteLine("{0} X {1}", quotient, currentDivisor);
                return true;
            }
        }
    }
