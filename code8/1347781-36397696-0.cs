    public class TestableClass
    {
        private ICommunications _comms;
        public TestableClass(ICommunications comms)
        {
            _comms = comms;
        }
        
        public bool FunctionToTest()
        {
            //do something testable
            _comms.SomeFunction();//mocked object in unit tests
            //do something else testable
        }
    }
