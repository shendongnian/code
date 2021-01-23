      static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Enter number between 2 and 12");
                int x = int.Parse(Console.ReadLine());
                if (!Enumerable.Range(1, 12).Contains(x))
                {
                    Console.WriteLine("{0} Its not Good\n",x);
                }
                else
                {
                    Console.WriteLine("{0} Its  Good\n",x);
                    break;
                }
            }
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
