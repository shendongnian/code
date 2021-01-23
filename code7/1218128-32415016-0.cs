    //Add reference of System.Numerics.dll
    using System.Numerics;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                BigInteger factorial = 1;
                var factorialOfNumber = 100;
                for (var i = 1; i <= factorialOfNumber; i++)
                {
                    factorial *= i;
                }
                Console.WriteLine("Required factorial of {0} is {1}", factorialOfNumber, factorial);
            }
        }
    }
