    static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input first number: ");
                var a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input second number: ");
                var b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input third number: ");
                var c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
                if (a > b && a > c)
                {
                    Console.WriteLine(a);
                }
                else if (b > a && b > c)
                {
                    Console.WriteLine(b);
                }
                else if (c > a && c > b)
                {
                    Console.WriteLine(c);
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
