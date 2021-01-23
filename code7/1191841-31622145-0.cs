    private static void Main(string[] args)
    {
        while (true)
        {
            ConsoleKeyInfo _key;
            _key = Console.ReadKey();
            switch ((char) _key.Key)
            {
                case '1':
                    Console.WriteLine(_key.Key);
                    break;
                case 'Q':
                    Console.WriteLine(_key.Key);
                    break;
            }
        }
    }
