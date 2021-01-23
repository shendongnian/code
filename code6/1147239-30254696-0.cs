    public class MyClass
    {
        public void Method()
        {
            Console.WriteLine("executed");
        }
    }
    
    public class MyActivator
    {
        public static void CreateInstance(Type type)
        {
            var instance = Activator.CreateInstance(type);
    
            var method = type.GetMethods().First(m => m.Name == "Method");
            method.Invoke(instance, null);
        }
    }
