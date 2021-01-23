    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		string text = "One";
    		TestEnum test = (TestEnum)Enum.Parse(typeof(TestEnum), text);
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
