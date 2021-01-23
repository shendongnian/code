        static void Main(string[] args)
        {
            ConsoleKeyInfo e;
            string userName = "";
            while (true)
            {
                e = Console.ReadKey();
                if (e.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (e.Key == ConsoleKey.F2)
                {
                    //things to do when F2
                }
                userName += e.KeyChar;
            }
            Console.WriteLine("username: " + userName);
            Console.Read();
        }
