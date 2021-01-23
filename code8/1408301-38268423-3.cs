    using System;
    public class Program
    {
        static public void Main()
        {
            string a = "12.14";
    
            string newA = a.PadRight(8, '0');
    		
    		Console.Write(newA);
        }
    }
