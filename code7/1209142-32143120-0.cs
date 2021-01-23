    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
    	public class Program
    	{
    		public static void Main(string[] args)
    		{
    			List<string> l1 = new List<string>();	
    
    			l1.Add("toto");l1.Add("titi") ;l1. Add("tata") ;l1.Add("tutu") ;l1.Add("tete");
    		
    			List<string> l2 = new List<string>();
    			l2.Add("toto"); l2.Add ("titi"); l2.Add ( "tata") ;
    
    			if (l2.All(l1.Contains))
    			{
    				System.Console.WriteLine("OK");
    			}
    			else 
    			{
    				System.Console.WriteLine("KO");
    			}
    
    		}
    	}
    }
