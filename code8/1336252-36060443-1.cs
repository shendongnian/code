    static void Main(string[] args)
        {
            var l = string.Empty;
            while (l != "exit")
            {
                l = Console.ReadLine();
                int i;
                if (!int.TryParse(l, out i)) continue;
                if (i % 2 == 0)
                {
                    Console.WriteLine("even");
                }
                Console.WriteLine("odd");
                Console.WriteLine("enter again");
            }
            Console.ReadLine();
        }
