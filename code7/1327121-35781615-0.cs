    public object Command
    {
        public void DoSomething()
        {
           //do something, act on values stored in member var;
        }
        public Command AddProp<T>(Expression<Func<T>> propAndValue)
        {
           // Get property and value from expression
           // store in member var
           return this;
        }
    }
    public class Foo
    {
        public long Id { get;set; } //LOOK: ITS A LONG PROPERTY
        public string Name { get; set; } // ITS A STRING PROPERTY
    }
    // Example usage
    Foo f = new Foo();
    Command cmd = new Command();
    cmd.AddProp(() => f.Id).AddProp(() => f.Name).DoSomething();
