    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		TestEnum test = TestEnum.One;
    		switch (test)
    		{
    			case TestEnum.One:
    			Console.WriteLine("ONE!");
    			break;
    			case TestEnum.Two:
    			Console.WriteLine("TWO!");
    			break;
    			case TestEnum.Three:
    			Console.WriteLine("THREE!");
    			break;
    		}
    	}
    	
    	public enum TestEnum
    	{
    		One,
    		Two,
    		Three
    	}
    }
