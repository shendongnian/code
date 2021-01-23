    public interface IMyClass
    {
        // has only getter so it's readonly
        int MyProperty { get;  }
    }
    class MyClass : IMyClass
    {
        private int myProperty;
        public int MyProperty 
        {
            // can be accessed from anywhere
            get
            {
               return myProperty;
            }
            // can be accessed only within current assembly
            internal set 
            {
               myProperty = value; 
            }
         }          
    }
    class Program
	{
        static void Main()
        {
            MyClass instance = new MyClass();
            instance.MyProperty = 10;
            // (instance as IMyClass).MyProperty = 20;      // error property cannot be assigned it's read-only
            Console.WriteLine((instance as IMyClass).MyProperty);
        }		
	}    
