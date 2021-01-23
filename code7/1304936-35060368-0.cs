    using System;
    
    public class Example
    {
       public static void Main()
       {
    	int a = 0000000;
    	int b = 17;
    	String s = String.Format("{0,10:0000000}",a+b);
    	Console.WriteLine(s);
       }
    }
    
