    using System;
    
					
    public class Program
    {
    	public static void Main()
    	{
    		string	str = "Re:_=C8SOB_Poji=9A=9Dovna";
    		char    ch, q;
    
    		for(int idx=0; idx<str.Length; idx++)
    		{
    			// Default - interpret as a single character
    			q = ' ';
    			ch = str[idx];
    			
    			if(str[idx]=='=' && idx+2<str.Length)
    			{
    				// Assume HEX, otherwise catch and use defaults
    				try {
    					ch = (char)Convert.ToInt32(str.Substring(idx+1,2),16);
    					idx+=2;
    					q = '"'; // "Quote" converted character
    				}
    				catch {};
    			}
    
    			// Do something with result
    			Console.WriteLine( "{0}{1}{2}", q, ch, q);
    		}		
    	}
    }
