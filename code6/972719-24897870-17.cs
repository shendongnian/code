    public static void TestCodeContract(int value)
    {
	    if(value > 100 && value < 110)
		    TestLimits(value); 
    }
    public static void TestLimits(int i)
    {
	    Contract.Requires(i > 100);
	    Contract.Requires(i < 110);
 
	    //Do Something
    }
