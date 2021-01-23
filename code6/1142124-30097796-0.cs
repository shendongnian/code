    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
            string a = "Main";
            switch (a)
            {
                case nameof(Program.Main):
                {
                    Console.WriteLine("Yes!");
                    break;
                }
            }
           
    	}
    }
