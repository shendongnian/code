    using System;
    					
    public class Program
    {
    	public static Sample sampleParam {get; set;} =new Sample();
    	public static void Main()
    	{
    
    		Console.WriteLine($"Name of property: {nameof(sampleParam)}");
    		Func(sampleParam);
    	}
    	
    	private static void Func(Sample s)
    	{
    		Console.Write($"Name of parameter: {nameof(s)}");
    	}
    	
    }
    
    public class Sample
    {
    	
    }
