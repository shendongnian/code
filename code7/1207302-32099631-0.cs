    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                double output = 1;
                const int iterations = 500;
                for (var i = 1; i <= iterations; i++)
                {
                    output = GetOutput(output);
                    Console.WriteLine("Number after {0} iterations is: {1}", i, output);
                }
                Console.WriteLine("Required Number is: {0}", output);
                VerifyResult(output, iterations);
                Console.ReadKey();
            }
            private static double GetOutput(double input)
            {
                if (input == 1)
                {
                    return 2;
                }
                var output = (input - 1) / 3;
                return output % 1 == 0 && output % 2 != 0 && output > 3 ? output : input * 2;
            }
    
            //To verify the above results we need this method
            private static void VerifyResult(double output, int iterations)
            {
                //-------------------------VERIFICATION-----------------------
                Console.WriteLine("Press any key to check iterations in reverse");
                Console.ReadKey();
                Console.WriteLine("Running validation process ...");
                var n = output;
                var max = n;
                var count = 0;
                Console.WriteLine("{0} (starting number in Collatz Sequence)", n);
                while (n > 1)
                {
                    n = n % 2 == 0 ? n / 2 : 3 * n + 1;
                    count++;
                    if (n > max) max = n;
                    Console.WriteLine(n);
                }
                if (count == iterations) //match here iterations and outputs
                {
                    Console.WriteLine("\n\nCONGRATULATION! Verification results matched. :-)\n\n");
                    Console.WriteLine("There are {0} cycle length in the sequence", count);
                    Console.WriteLine("The largest number in the sequence is {0}", output);
                    Console.WriteLine("\n\n-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                    Console.WriteLine("\n\nREQUIRED NUMBER: {0}\n\n", output);
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-\n");
                    Console.WriteLine("\nPress any key to exit");
                }
                else
                {
                    Console.WriteLine("Oops... Verification results are not matching. :-(");
                }
            }
        }
    }
