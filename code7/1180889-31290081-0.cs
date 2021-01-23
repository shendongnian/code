        static void Main(string[] args)
        {
            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();
            engine.Initialize();
            engine.Evaluate("x <- 40 + 2");
            engine.Evaluate("s <- paste('hello', letters[5])");
            var x = engine.GetSymbol("x").AsNumeric().First();
            var s = engine.GetSymbol("s").AsCharacter().First();
            Console.WriteLine(x);
            Console.WriteLine(s);
        }
