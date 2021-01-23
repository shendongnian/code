    void Main()
    {
    	PrintSize<DateTimeOffset>();
    }
    
    public static void PrintSize<T>() 
    {
    	GC.Collect();
    	long gc1 = GC.GetTotalMemory(true);
    	const int sz = 100000;
    	T[] foo = new T[sz];
    	long gc2 = GC.GetTotalMemory(true);
    	GC.KeepAlive(foo);
    	Console.WriteLine($"{(gc2 - gc1) / (double)sz} bytes per {typeof(T)}");
    }
