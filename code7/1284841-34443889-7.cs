    CommandContext root = new CommandContext(
        "root",
        new Command("multiply", new Action<int, int>(Multiplication)),
        new CommandContext(
            "somecontext",
            // ...
            )
        );
    ArgumentEnumerator args = new ("add /x:6 /y:7");
    
    root.Execute(args);
    
    public static void Multiplication([Argument("x")] int x, [Argument("y")] int y)
    {
        // No parsing, only logic
        int result = x * y;
    }
