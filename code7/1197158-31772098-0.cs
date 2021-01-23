    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<string> fileLines = new List<string>
    		{
    			"MINOR_PSIST                    : 2          MAJOR_PSIST                    : 8        ",
    			"CRITICAL_PSIST                 : 60         ECSFB_CALL_CONTROL_TYPE        : AUTOMATIC",
    			"CALL_CONTROL_TYPE              : AUTOMATIC  REGI_CONTROL_TYPE              : AUTOMATIC",
    			"PAGE_CONTROL_TYPE              : AUTOMATIC  THRESHOLD_TIME                 : 1        ",
    			"ECSFB_PER_UNIT_SEC_IN_NORMAL   : 0          CALL_PER_UNIT_SEC_IN_NORMAL    : 0        ",
    			"REGI_PER_UNIT_SEC_IN_NORMAL    : 0          PAGE_PER_UNIT_SEC_IN_NORMAL    : 1800     ",
    			"ECSFB_PER_UNIT_SEC_IN_MINOR    : 25         CALL_PER_UNIT_SEC_IN_MINOR     : 25       ",
    			"REGI_PER_UNIT_SEC_IN_MINOR     : 50         PAGE_PER_UNIT_SEC_IN_MINOR     : 25       ",
    			"ECSFB_PER_UNIT_SEC_IN_MAJOR    : 20         CALL_PER_UNIT_SEC_IN_MAJOR     : 20       ",
    			"REGI_PER_UNIT_SEC_IN_MAJOR     : 40         PAGE_PER_UNIT_SEC_IN_MAJOR     : 5        ",
    			"ECSFB_PER_UNIT_SEC_IN_CRITICAL : 15         CALL_PER_UNIT_SEC_IN_CRITICAL  : 15       ",
    			"REGI_PER_UNIT_SEC_IN_CRITICAL  : 30         PAGE_PER_UNIT_SEC_IN_CRITICAL  : 1        ",
    			"UNIT_SECOND_INTERVAL           : 3          ",
    			"RESULT = OK",
    			"COMPLETED	"
    		};
    		
    		// Each group contains a colon
    		var groupLines = fileLines.Where(line => line.Contains(":"));
    		
    		// Break out each group to its own line
    		List<string> groups = new List<string>();
    		foreach (string line in groupLines)
    		{
    			groups.Add(line.Substring(0, 42));
    			if (line.Length > 44)
    			{
    				groups.Add(line.Substring(44));
    			}
    		}
    		
    		// Build the dictionary from the groups
    		Dictionary<string, string> dictionary = groups.Select(line => line.Split(':'))
    			.GroupBy(pieces => pieces[0].Trim(), pieces => pieces[1].Trim())
    			.ToDictionary(kvp => kvp.Key, kvp => kvp.First());
    		
    		// Print the dictionary to verify success
    		foreach (var r in dictionary)
    		{
    			Console.WriteLine("Key: {0,-35} Value: {1}", r.Key, r.Value);
    		}
    	}
    }
