    void Main()
    {
    	try{
    		DoSomething();
    	}
    	catch{
    		Console.WriteLine("Yup. Breaks");
    	}
    }
    void DoSomething()
    {
    	for(int i = 0; i <= 1; i++)
    	{
    		if(i == 0) {
    			throw new NotImplementedException();
    		}
    		if( i != 0)
    		{
    			Console.WriteLine("Loop continues");
    		}
    	}
    }
