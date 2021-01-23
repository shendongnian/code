    using System;
    using System.IO;
    
    public class Program
    {
    	public static void Main()
    	{
    		using (var fileStream = File.Open(@"c:\test.txt", FileMode.Open))
    		{
    			using (var streamReader = new StreamReader(fileStream))
    			{
    				string line = "";
    				while (line != "BLOCK2" && line != null)
                    {
    					line = streamReader.ReadLine();
                    }
    				line = streamReader.ReadLine();
    				while (line != "ENDOFBLOCK" && line != null)
    				{
    					Console.WriteLine(line);
    					line = streamReader.ReadLine();
    				}
    			}
    		}
    	}
    }
