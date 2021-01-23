    using System.IO;
    using System.Text.RegularExpressions;
    
    // Same regex from before shortened to one line for brevity
    Regex CSVParser = new Regex(
        @"(?<=\r|\n|^)(?!\r|\n|$)(?:(?:""(?<Value>(?:[^""]|"""")*)""|(?<Value>(?!"")[^,\r\n]+)|""(?<OpenValue>(?:[^""]|"""")*)(?=\r|\n|$)|(?<Value>))(?:,|(?=\r|\n|$)))+?(?:(?<=,)(?<Value>))?(?:\r\n|\r|\n|$)",
        RegexOptions.Compiled);
    
    String CSVSample = ",record1 value2,val3,\"value 4\",\"testing \"\"embedded double quotes\"\"\",\"testing quoted \"\",\"\" character\", value 7,,value 9,\"testing empty \"\"\"\" embedded quotes\",\"testing a quoted value," + 
        Environment.NewLine + Environment.NewLine + "that includes CR/LF patterns" + Environment.NewLine + Environment.NewLine + "(which we wish would never happen - but it does)\", after CR/LF," + Environment.NewLine + Environment
        .NewLine + "\"testing an open ended quoted value" + Environment.NewLine + Environment.NewLine + ",value 2 ,value 3," + Environment.NewLine + "\"test\"";
    
    using (StringReader CSVReader = new StringReader(CSVSample))
    {
        String CSVLine = CSVReader.ReadLine();
        StringBuilder RecordText = new StringBuilder();
        Int32 RecordNum = 0;
    
        while (CSVLine != null)
        {
            RecordText.AppendLine(CSVLine);
            MatchCollection RecordsRead = CSVParser.Matches(RecordText.ToString());
            Match Record = null;
            
            for (Int32 recordIndex = 0; recordIndex < RecordsRead.Count; recordIndex++)
            {
                Record = RecordsRead[recordIndex];
            
                if (Record.Groups["OpenValue"].Success && recordIndex == RecordsRead.Count - 1)
                {
                    // We're still trying to find the end of a muti-line value in this record
                    // and it's the last of the records from this segment of the CSV.
                    // If we're not still working with the initial record we started with then
                    // prep the record text for the next read and break out to the read loop.
                    if (recordIndex != 0)
                        RecordText.AppendLine(Record.Value);
                    
                    break;
                }
                
                // Valid record found or new record started before the end could be found
                RecordText.Clear();            
                RecordNum++;
                
                for (Int32 valueIndex = 0; valueIndex < Record.Groups["Value"].Captures.Count; valueIndex++)
                {
                    Capture c = Record.Groups["Value"].Captures[valueIndex];
                    Console.Write("R" + RecordNum + ":V" + (valueIndex + 1) + " = ");
                    if (c.Length == 0 || c.Index == Record.Index || Record.Value[c.Index - Record.Index - 1] != '\"')
                        Console.WriteLine(c.Value);
                    else
                        Console.WriteLine(c.Value.Replace("\"\"", "\""));
                }
                
                foreach (Capture OpenValue in Record.Groups["OpenValue"].Captures)
                    Console.WriteLine("R" + RecordNum + ":ERROR - Open ended quoted value: " + OpenValue.Value);
            }
            
            CSVLine = CSVReader.ReadLine();
            
            if (CSVLine == null && Record != null)
            {
                RecordNum++;
                
                //End of file - still working on an open value?
                foreach (Capture OpenValue in Record.Groups["OpenValue"].Captures)
                    Console.WriteLine("R" + RecordNum + ":ERROR - Open ended quoted value: " + OpenValue.Value);
            }
        }
    }
