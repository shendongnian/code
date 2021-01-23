    using System;
    
    namespace EmailHash
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			if (args.Length <= 0) 
                {
    				Console.WriteLine ("No values were passed to application.");
    				return;
    			}
    			string email = args[0];
    
    			int indexOfAt = email.IndexOf ("@");
    			if (indexOfAt == -1) 
                {
    				Console.WriteLine("Unable to find '@' symbol within email.");
    				return;
    			}
    
    			int indexStart = 3;
    			int indexEnd = indexOfAt - 2;
    			if (indexStart >= indexEnd)
    			{
    				Console.WriteLine("Not enough characters in email to mask value.");
    				return;
    			}
    
    			string hashedEmail = email.Replace(email.Substring(indexStart, indexEnd - indexStart), "***");
    
    			Console.WriteLine("Original email: " + email);
    			Console.WriteLine("Hashed email: " + hashedEmail);
    			return;
    		}
    	}
    }
