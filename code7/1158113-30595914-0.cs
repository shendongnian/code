    class CommandProcessor
    {
        static void Execute(ICommand command)
        {
            command.Execute();
        }
    }
