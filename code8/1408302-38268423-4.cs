    using System;
    
    public class Program
    {
        static public void Main()
        {
            string a = "332.143";
    				
    		int padLen = (5 - (a.Length - a.IndexOf('.') - 1)) + a.Length;
    				
            string newA = a.PadRight(padLen, '0');
    		
    		Console.WriteLine(newA);		
        }
    
    }
