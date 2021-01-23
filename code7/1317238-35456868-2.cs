     internal class MyService
            :IMyService
        {
            public MyService()
            {
                Console.WriteLine("with no parameters");
            }
    
            public MyService(IServiceLogger logger)
            {
                Console.WriteLine("with logger parameters");
            }
        }
