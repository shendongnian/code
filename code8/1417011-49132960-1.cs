    public class MyClass
    {
    #if NetFramework
        public void MyMethod()
        {
            Console.WriteLine("framework is supported");
            // and do anything with libraries available in the framework :)
        }
    #endif
    }
