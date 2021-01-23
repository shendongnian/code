        static void Main(string[] args)
        {
            UserInput UI = new UserInput();
            Crypting CR = new Crypting();
            FileHandling FH = new FileHandling();
            Console.WriteLine(UI.test);
            Console.WriteLine(UI.test2);
            FH.TextFile = UI.test2;
            FH.LoadingFile();
        }
