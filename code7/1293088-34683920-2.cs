    public class MockFoo : IFoo
    {
        string trueValue;
    
        public MockFoo(string trueValue)
        {
            this.trueValue = trueValue;
        }
    
        public bool DoSomething(string value)
        {
            return value == trueValue;
        }
    }
