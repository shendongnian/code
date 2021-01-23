    interface IPrinter<in T>
    {
        void Print(T args);
    }
    
    class IntPrinter : IPrinter<int>
    {
        public void Print(int args)
        {
            Console.WriteLine("This is int: " +args);
        }
    }
    
    class StringPrinter : IPrinter<string>
    {
        public void Print(string args)
        {
            Console.WriteLine("This is string: " + args);
        }
    }
    
    interface IPrintWrapper 
    {
        void Print(object printer, object args);
    }
    
    class PrintWrapper<T> : IPrintWrapper
    {
        public void Print(object printer, object args)
    	{
    	     ((IPrinter<T>)printer).Print((T)args);
    	}
    }
    
    private readonly Dictionary<Type, IPrintWrapper> Wrappers = new Dictionary<Type, IPrintWrapper>();
    
    private void Print(object printer, object arg)
    {
         var type = arg.GetType();
        IPrintWrapper wrapper;
    	if (!Wrappers.TryGetValue(type, out wrapper))
    	{
    	    var wrapperType = typeof(PrintWrapper<>).MakeGenericType(type);
    	    Wrappers[type] = wrapper = (IPrintWrapper)Activator.CreateInstance(wrapperType);
    	}
    	wrapper.Print(printer, arg);
    }
    
    void Main()
    {
       var printer1 = new IntPrinter();
       var printer2 = new StringPrinter();
       Print(printer1, 1);
       Print(printer1, 2);
       Print(printer2, "asfasfasf");
    }
