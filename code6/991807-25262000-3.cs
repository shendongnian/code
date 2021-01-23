    public class MyClient
    {
        public MyClient(SomeService.Factory serviceFactory)
        {
            _myService = serviceFactory("this", "that");
        }
    }
