    public class MyService : IMyService
    {
        AnotherClass _anotherObject;
        // ...
    
        public MyService(AnotherClass anotherObject)
        {
            _anotherObject = anotherObject;
        }
    
        // ...
    }
