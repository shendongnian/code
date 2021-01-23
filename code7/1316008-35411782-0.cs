    using System;
    using System.IO;
    using System.Linq;
    
    public class Test
    {
    	public static void Main()
    	{
    		var line = "\"test\"  \"--test\" \"test\" \"--test\" \"test\" \"--test\" \"test\" \"--test\" \"test\" \"--test\" \"test\" \"--test\" \"--test\" \"test\" \"--test\" \"test\" \"--test\" \"test\"\"--test\" \"--test\" \"--test\" \"--test\" \"--test\" \"test\" \"--test\" \"--test\" \" test \"";
            var splts = line.Split(new[]{"\\\""}, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(string.Join("\n", splts));
    	}
    }
