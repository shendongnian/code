    public class BasicCommand
    {
        private Action<BasicCommand> _action;
        public BasicCommand(Action<BasicCommand> action)
        {
             _action = action;
        }
    
        public int Parameter1 {get;set;}
    
        public void Execute()
        {
             _action(this);
        }
    }
    
    
    public class SomeFooClass
    {
        public void SomeFoo()
        {
            //use of unassigned variable here: obj
            BasicCommand obj = new BasicCommand((o) => SomeOtherFoo(o.Parameter1));
    
            obj.Execute();
        }
    }
     
