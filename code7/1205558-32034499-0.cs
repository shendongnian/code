    class TestClass
    {
        public event Action<string> MethodCall;
        
        public void Add()
        {
            MethodCall("Add Called");
            
            Edit();
        }
        
        public void Edit()
        {
            MethodCall("Edit Called");
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            var c = new TestClass();
            c.MethodCall += Console.WriteLine;
            
            c.Add();
            
            Console.ReadKey();
        }
    }
