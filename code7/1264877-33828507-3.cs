    void Foo(int bar)
    {
    	Console.WriteLine(bar);
    	if(bar < 10)
    		MethodBase.GetCurrentMethod().Invoke(this, new object[] {++bar});
    	else
    		Console.WriteLine("Finished");
    }
