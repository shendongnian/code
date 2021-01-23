    public class Class2
    {
    	public void Method4()
    	{
    	    //uses values 1-4 from class1 
    		var c = new Class1();
    		
    		c.Method1();
    		c.Method2();
    		
    		Console.WriteLine(c.Value1);
    		Console.WriteLine(c.Value2);
    		Console.WriteLine(c.Value3);
    		Console.WriteLine(c.Value4);
    	}
    }
