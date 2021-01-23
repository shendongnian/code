    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var log = "attribute1=value1 attribute2=value2 dll=aDllName dll=anotherDllName, someParam=ParamValue dll=yetAnotherDll, someOhterParam=anotherParamValue aStandAloneValue dll=oneMoreDll, andItsParam=value anotherParam=value lastParam=value";
    		var res = Regex.Split(log, @"(?=\b(?:attribute\d*|dll)=)")
    		         .Where(p => !string.IsNullOrWhiteSpace(p))
    		         .ToList();
    		Console.WriteLine(string.Join("\n",res));
    	}
    }
