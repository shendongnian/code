    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Run(new Stack<string>(args.Reverse()));
            Console.ReadKey();
        }
        private readonly Dictionary<string, Action<Stack<string>>> commands;
        public Program() {
            commands =
                new Dictionary<string, Action<Stack<string>>>
                {
                    {"u", DestroyUniverse },
                    {"g", DestroyGalaxy },
                    {"p", DestroyPlanet },
                    {"t", TimeTravel }       
                };
         }
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
        private string Next(Stack<string argStack)
        {
            // wish this was a method of Stack<T>
            return argStack.Any() ? argStack.Pop() : null;
        }
        public void Run(Stack<string> argStack)
        {
            var cmd = Next(argStack);
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
            action(argStack);
        }
    }
