       static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            int i = 0;
            do
            {
             
                while (Console.KeyAvailable == false)
                    Thread.Sleep(250); // Loop until input is entered.
                cki = Console.ReadKey(true);
            
                if (cki.Key == ConsoleKey.F1)
                {
                    Console.WriteLine("User Have Press F1");
                    //do some thing
                }
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("User Have Press Enter");
                    //do some thing
                }
                if (cki.Key == ConsoleKey.A)
                {
                    Console.WriteLine("User Have Press A");
                    //do some thing
                }
            } while (cki.Key != ConsoleKey.X);
        }
