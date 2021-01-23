    static class Program {
        static int Main(string[] args) {
            if (args.Length == 0)
                return 0;
    
            return Int32.Parse(args[0]);
        }
    }
