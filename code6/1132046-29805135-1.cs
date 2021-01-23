        static void Command1() { }
        static void Command2() { }
        static readonly Dictionary<string, Action> commands = new Dictionary<string, Action>(){
            { "command1", Command1 },
            { "command2", Command2 }
        };
