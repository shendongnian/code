    public class MyClient
    {
        public MyClient(SomeService.Factory serviceFactory)
        {
            // Resolve ISomeService using factory method
            // passing runtime parameters
            _myService = serviceFactory("this", "that");
        }
    }
