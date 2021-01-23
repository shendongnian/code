	using System.Text.RegularExpressions;
    Regex CSVParser = new Regex(
        @"(?<=\r|\n|^)(?!\r|\n|$)" +
        @"(?:" +
            @"(?:" +
                @"""(?<Value>(?:[^""]|"""")*)""|" +
                @"(?<Value>(?!"")[^,\r\n]+)|" +
                @"""(?<OpenValue>(?:[^""]|"""")*)(?=\r|\n|$)|" +
                @"(?<Value>)" +
            @")" +
            @"(?:,|(?=\r|\n|$))" +
        @")+?" +
        @"(?:(?<=,)(?<Value>))?" +
        @"(?:\r\n|\r|\n|$)",
        RegexOptions.Compiled);
    
    String CSVSample =
        ",record1 value2,val3,\"value 4\",\"testing \"\"embedded double quotes\"\"\"," +
        "\"testing quoted \"\",\"\" character\", value 7,,value 9," +
        "\"testing empty \"\"\"\" embedded quotes\"," +
        "\"testing a quoted value" + Environment.NewLine +
        Environment.NewLine +
        "that includes CR/LF patterns" + Environment.NewLine +
        Environment.NewLine +
        "(which we wish would never happen - but it does)\", after CR/LF" + Environment.NewLine +
        Environment.NewLine +
        "\"testing an open ended quoted value" + Environment.NewLine +
        Environment.NewLine +
        ",value 2 ,value 3," + Environment.NewLine +
        "\"test\"";
    
    MatchCollection CSVRecords = CSVParser.Matches(CSVSample);
    
    for (Int32 recordIndex = 0; recordIndex < CSVRecords.Count; recordIndex++)
    {
        Match Record = CSVRecords[recordIndex];
    
        for (Int32 valueIndex = 0; valueIndex < Record.Groups["Value"].Captures.Count; valueIndex++)
        {
            Capture c = Record.Groups["Value"].Captures[valueIndex];
            Console.Write("R" + (recordIndex + 1) + ":V" + (valueIndex + 1) + " = ");
    
            if (c.Length == 0 || c.Index == Record.Index || Record.Value[c.Index - Record.Index - 1] != '\"')
            {
                // No need to unescape/undouble quotes if the value is empty, the value starts
                // at the beginning of the record, or the character before the value is not a
                // quote (not a quoted value)
                Console.WriteLine(c.Value);
            }
            else
            {
                // The character preceding this value is a quote
                // so we need to unescape/undouble any embedded quotes
                Console.WriteLine(c.Value.Replace("\"\"", "\""));
            }
        }
        
        foreach (Capture OpenValue in Record.Groups["OpenValue"].Captures)
            Console.WriteLine("ERROR - Open ended quoted value: " + OpenValue.Value);
    }
