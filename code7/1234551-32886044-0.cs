    public class NamedAction
    {
        private readonly Action _action;
        public string Name { get; }
    
        public NamedAction(Action action, string name)
        {
            _action = action;
            Name = name;
        }
    
        public void Invoke()
        {
            _action.Invoke();
        }
    }
