    using System;
    using System.Text;
					
    public class Program
    {
	    public static void Main()
	    {
		    var baseString = "1,";
		    var builder = new StringBuilder();
		
		    for(var i=0;i<599;i++)
		    {
			    builder.Append(baseString);
		    }
		    builder.Append("1");
		
		    var result = builder.ToString().Split(',');
		
		    Console.WriteLine("Number of parts:{0}",result.Length);
	    }
    }
