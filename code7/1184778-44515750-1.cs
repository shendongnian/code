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
    
    interface IPrintInvoker
    {
        void Print(object printer, object args);
    }
    
    class PrintInvoker<T> : IPrintInvoker
    {
        public void Print(object printer, object args)
    	{
    	     ((IPrinter<T>)printer).Print((T)args);
    	}
    }
    
    private readonly Dictionary<Type, IPrintInvoker> Invokers = new Dictionary<Type, IPrintInvoker>();
    
    private void Print(object printer, object arg)
    {
         var type = arg.GetType();
        IPrintInvoker invoker;
    	if (!Invokers.TryGetValue(type, out invoker))
    	{
    	    var invokerType = typeof(PrintInvoker<>).MakeGenericType(type);
    	    Invokers[type] = invoker = (IPrintInvoker)Activator.CreateInstance(invokerType );
    	}
    	invoker.Print(printer, arg);
    }
    
    void Main()
    {
       var printer1 = new IntPrinter();
       var printer2 = new StringPrinter();
       Print(printer1, 1);
       Print(printer1, 2);
       Print(printer2, "asfasfasf");
    }
