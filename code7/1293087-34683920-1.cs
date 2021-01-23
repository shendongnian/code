    public class TestObject 
    {
        public string TestMethod(IFoo foo)
        {
            if (foo.DoSomething("ping"))
                return "ping";
            else if (foo.DoSomething("pong"))
                return "pong";
            return "blah";
        }
    }
