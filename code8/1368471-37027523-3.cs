    using System;
    			
    public class Program
    {
    	public static void Main()
    	{
    		string str = "Re:_=C8SOB_Poji=9A=9Dovna";
    
    		for(int idx=0; idx<str.Length; idx++)
    		{
    			if(str[idx]=='=' && idx+2<str.Length)
    			{
    				Console.WriteLine(
						"["
    					+ (char)Convert.ToInt32(str.Substring(idx+1,2),16)
    					+ "]");
    				idx+=2;
    			}
    			else
    				Console.WriteLine(" " + str[idx] + " ");
    		}		
    	}
    }
