    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var log = "time=value1 size=value2 dll=aDllName dll=anotherDllName, someParam=ParamValue dll=yetAnotherDll, someOhterParam=anotherParamValue aStandAloneValue dll=oneMoreDll, andItsParam=value anotherParam=value lastParam=value";
    		var res = Regex.Matches(log, @"\bdll=(?:(?!\bdll=).)*|\w+=\w+")
    		         .Cast<Match>()
    		         .Select(p => p.Value)
    		         .ToList();
    		Console.WriteLine(string.Join("\n",res));
    	}
    }
