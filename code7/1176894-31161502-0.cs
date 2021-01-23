    public class MyEventArgs : EventArgs
    {
        public string Name {get; private set;}
        public MyEventArgs(EventArg e, string name)
        {
            this.Name = name;
        }
    }
    
    mysys.ValueChanged += (sender, e) => mysys_ValueChanged(sender, new MyEventArgs("some name"));
