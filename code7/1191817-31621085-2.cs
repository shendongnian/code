    using System.IO;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		int expectedNumberOfTabs = 5;
    		string originalFile = "MyFile.txt";
    		string originalFileFixed = "MyFileFixed.txt";
    		
    		using (StreamReader sr = new StreamReader(originalFile))
    		using (StreamWriter sw = new StreamWriter(originalFileFixed))
    		{
    			string line = sr.ReadLine();
    			if (line.Count(c => c == '\t') != expectedNumberOfTabs)
    			{
    				// line = ...Fix the line
    			}
    			
    			sw.WriteLine(line);
    		}
    		
    		// Delete original file
    		File.Delete(originalFile);
    		// Rename the fixed file back to the original file
    		File.Move(originalFileFixed, originalFile);
    		
    		// Import the file
    	}
    }
