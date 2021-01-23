    public interface IMyClass
    {
        // has only getter and is read-only
        int MyProperty { get;  }
        string MyMethod();
    }
    class MyClass : IMyClass
    {        
        // setter can be accessed only from current assembly
        public int MyProperty { get; internal set; }
        // this method can by invoked from interface (explicit implementation)
        string IMyClass.MyMethod()
        {
            return "logic for your interface to use outside the assembly";        
        }
        // this method can by invoked from current assembly only
        internal string MyMethod()
        {
            return "logic inside the assembly";
        }
    }
    class Program
	{
        static void Main()
        {
            MyClass instance = new MyClass();
            instance.MyProperty = 10;
            // (instance as IMyClass).MyProperty = 20;        property cannot be assigned it's read-only
            Console.WriteLine((instance as IMyClass).MyProperty);
            Console.WriteLine((instance as IMyClass).MyMethod());
            Console.WriteLine(instance.MyMethod());
        }		
	}    
