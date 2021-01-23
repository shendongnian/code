    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class File
    {
    	public string Name;
    	public string Extension;
    	
    	public override string ToString()
    	{
    		return string.Format("File: {0}, Extension: {1}", Name, Extension);
    	}
    }
    
    
    public class Program
    {
    	public static void Main()
    	{
    		var files = new List<File>()
    		{
    			new File {Name="1", Extension = ".exe"},
    			new File {Name="2", Extension = ".txt"},
    			new File {Name="3", Extension = ".ini"},
    			new File {Name="4", Extension = ".exe"},
    			new File {Name="5", Extension = ".zip"},
    			new File {Name="6", Extension = ".jpg"}
    		};
    		
    		var extensions = new[]{".txt", ".exe"};
    		
    		
    		Console.WriteLine(string.Join("\n", files.OrderByDescending(f => extensions.Contains(f.Extension))));
    	}
    }
