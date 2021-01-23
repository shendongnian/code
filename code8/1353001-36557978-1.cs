    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static int computeProd1(int num1, int num2)
            {
                return (num1 * num2);
    
            }
    
            public static void Main(string[] args)
    
            {
                try
                {
                    int first, second, product = 0;
    
                    if (int.TryParse(Console.ReadLine(), out first))
                    {
                        if (int.TryParse(Console.ReadLine(), out second))
                        {
                            product = computeProd1(first, second);
                        }
                        else
                        {
                            Restart();
                        }
                    }
                    else
                    {
                        Restart();
                    }
    
                    
                    Console.WriteLine("Their product is:\t" + product);
    
                    Console.ReadLine();// So it wont close.
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
    
            public static void Restart()
            {
                Console.WriteLine("Oops something went wrong thats not a number!");
                Console.WriteLine("Restarting in 3 seconds...");
                System.Threading.Thread.Sleep(3000);
                var fileName =   System.Reflection.Assembly.GetExecutingAssembly().Location;
                System.Diagnostics.Process.Start(fileName);
                Environment.Exit(0);
            }
        }
    }
