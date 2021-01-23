    static void Main(string[] args)
        {
            var l = string.Empty;
            while (l != "exit")
            {
                l = Console.ReadLine();
                int i;
                if (!int.TryParse(l, out i)) continue;
                Console.WriteLine(i%2 == 0 ? "even" : "odd");
                Console.WriteLine("enter again");
            }
            Console.ReadLine();
        }
