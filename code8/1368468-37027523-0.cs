    using System;
    
    					
    public class Program
    {
    	public static void Main()
    	{
    		string str = "Re:_=C8SOB_Poji=9A=9Dovna";
    
    		while(str.Length>0)
    		{
    			if(str[0]=='=')
    				Console.WriteLine(str.Substring(0,3));
    			else
    				Console.WriteLine(str[0]);
    			str = str.Substring(1);
    		}		
    	}
    }
