    public class MyController 
    {
        private readonly MyClass myClass;
        public MyController()
        {
            // This doesn't work and do not involve DI at all
            // It will fail because MyClass has no parameterles constructor
            this.myClass = new MyClass(); 
        }
    }
