    public class ConcreteHandler: IHandler
    {
        public void DoSomething(string s) { ... }
    }
    // example
    var test = new MyType(new ConcreteHandler());
    test.Handler.DoSomething("test");
