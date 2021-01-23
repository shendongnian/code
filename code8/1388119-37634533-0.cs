    using System;
    using System.IO;
    
    public class Test
    {
    	public static void Main()
    	{
    		var s = @"Sprites\/tilesTest.png";
    		Console.Write(GetStr(s));
    	}
    	public static string GetStr(string s) {
    		return Path.Combine(Path.GetDirectoryName(s), Path.GetFileNameWithoutExtension(s)).Replace(@"\/", "/");
    	}
    }
