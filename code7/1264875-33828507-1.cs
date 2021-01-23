    void Foo(int bar)
    {
    	Console.WriteLine(bar);
    	if(bar < 10)
    		new StackFrame().GetMethod().Invoke(this, new object[] {++bar});
    	else
    		Console.WriteLine("Finished");
    }
