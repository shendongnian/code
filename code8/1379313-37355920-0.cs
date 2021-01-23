        static void Main(string[] args)
        {
            char c = '.';
            while (true)
            {
                if (Console.KeyAvailable) // check KeyAvailable since ReadKey is a blocking call
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true - will intercept the key and won't show it
                    c = keyInfo.KeyChar;
                }
                Console.Write(c);
            }
        }
