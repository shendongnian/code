    using System;
    using System.Collections.Generic;
    namespace firstconsoleproject
    {
    	class MainClass
    	{
    		public static void Main (string[] args)    
    		{
    			int first=4;
    			int c=0;
    			int ax;
    			int ai;
    			Console.WriteLine ("please enter n");
    			ax = Convert.ToInt32( Console.ReadLine());
    			for (int i=11 ; ax>0 ;)
    			{   if (first==1) 
    				{
    					c = ax+1;
    					i++;
    				}	
    				c--;
    				ai=i*c;
    					for (int ten=10 ;  ; )
    				{	
    					     if(ai%ten==2)
    					     {
    						first=0;	
    						break;						    
    					     }else if (ai==0)
    					    {
    						first=1;
    						break; 
    						}
    					     ai/=10;
    				   
    				}
    				
    				if (c==0){Console.WriteLine("number is "+i);break;}
    			
    		    	}Console.ReadKey ();
    				
    	      }
          }
    }
    	
    	
    		
    	
    	
  
