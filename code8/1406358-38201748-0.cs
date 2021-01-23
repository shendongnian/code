    using System;
    using System.IO;
    using System.Text;
    public class Test
    {
	   public static void Main()
	   {
            String line = String.Empty;
        	while(!String.IsNullOrEmpty((line = streamReader.ReadLine())))
            {
	            if(line.StartsWith("Latitude:"))
	            {
	            	line = line.Substring(line.LastIndexOf(' ') + 1);
	            	Console.WriteLine(line);
	            }
            }
            Console.ReadKey();
	   }
    } 
