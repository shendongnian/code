    public class Class1
    {
        // these are properties
    	public int Value1 { get; set; }
    	public int Value2 { get; set; }
    	public int Value3 { get; set; }
    	public int Value4 { get; set; }
    	
    	public void Method1()
    	{
    		Value1 = 1;
    		Value2 = 2;
    	}
    
    	public void Method2()
    	{
    		Value3 = 3;
    		Value4 = 4;
    	}
    
    	public void Method3()
    	{
        	// uses method4 from class2 
    		var c = new Class2();
    		c.Method4();
    	}
    }
    
