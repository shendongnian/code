    public static IWebDriver GetDriver()
        {
            IWebDriver driver = new PhantomJSDriver();
            ClearCurrentConsoleLine();
            return driver;
        }
        public static void ClearCurrentConsoleLine()
        {
            int pos = Console.CursorTop;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - i);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0,pos);
            }
            Console.SetCursorPosition(0,Console.CursorTop-19);
        }
