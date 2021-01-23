    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(A.GetInstance());
    		Console.WriteLine(A<int>.GetInstance());
    		Console.WriteLine(A.GetInstance<bool>());
    		/*
    			output :
    			Program+A
    			Program+A`1[System.Int32]
    			Program+A`1[System.Boolean]
    		*/
    	}
