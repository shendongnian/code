    public class MyController 
    {
        private readonly MyClass myClass;
        public MyController(MyClass myClass)
        {
            // This should work, because the IoC/DI Container creates the instance
            // and pass it into the controller
            this.myClass = myClass;
        }
    }
