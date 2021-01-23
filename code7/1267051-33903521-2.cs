    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            commands.Add("u", p.DestroyUniverse);
            commands.Add("g", p.DestroyGalaxy);
            p.Run(new Stack<string>(args.Reverse()));
            Console.ReadKey();
        }
        private static readonly Dictionary<string, Action<Stack<string>>> 
            commands = new Dictionary<string, Action<Stack<string>>>();
        public void DestroyUniverse(Stack<string> argStack)
        {
            // destroy the universe according to the options in argStack
            // ...
        }
        public void DestroyGalaxy(Stack<string> argStack)
        {
            // destroy the galaxy according to the options in argStack
            // ...
        }
        public void Run(Stack<string> argStack)
        {
            string cmd = null;
            Action<Stack<string>> action = null;
            // if no command given, or command is not found, tell
            // user the list of available commands
            if (cmd == null || !commands.TryGetValue(cmd, out action))
            {
                Console.WriteLine("Available Commands:{0}{1}",
                    Environment.NewLine,
                    string.Join(Environment.NewLine,
                        commands.OrderBy(kv => kv.Key)
                            .Select(kv => string.Format("{0} - {1}",
                                 kv.Key, kv.Value.Method.Name))));
                Environment.ExitCode = 1;
                return;
            }
            // command is valid, call the method
            if (action != null)
            {
                action.Invoke(argStack);
            }
        }
    }
