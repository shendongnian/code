    public class BasicCommand
    {
        private Action _action;
        public BasicCommand(Action action)
        {
             _action = action;
        }
        public int Parameter1 {get;set;}
        public void Execute()
        {
             _action.Invoke();
        }
    }
