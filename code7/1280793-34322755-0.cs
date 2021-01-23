    public class CommandButton : Button
    {
        public Action<CommandButton> Execute { get; set; }
        public CommandButton (Action<CommandButton> action)
        {
            Execute = action;
        }
    }
