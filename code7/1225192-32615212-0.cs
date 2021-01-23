    using System;
 
    public class Test
    {
	    public static void Main()
    	{
	    	var dataString = string.Format("email_address:{0}, status:subscribed, merge_fields:{1}", "a", "b");
		    Console.WriteLine(dataString);
    	}
    }
