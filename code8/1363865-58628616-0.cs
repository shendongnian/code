    //I'm using Tuple Types and Interpolated Strings which are available in C# 7 and .NET 4.7+
    (int, int, int) maxFieldLengths = (10, 10, 10); //Use 10 as the min length
    List<(string, string, string)> values = new List<(string, string, string)>();
    values.Add(("header1", "header2", "header3"));
    values.Add(("value1", "value2", "value3"));
    values.Add(("longerstringvalue", "value4", "evenlongerstringvaluehere"));
    
    foreach (var value in values)
    {
    	maxFieldLengths.Item1 = Math.Max(maxFieldLengths.Item1, value.Item1.Length);
    	maxFieldLengths.Item2 = Math.Max(maxFieldLengths.Item2, value.Item2.Length);
    	maxFieldLengths.Item3 = Math.Max(maxFieldLengths.Item3, value.Item3.Length);
    }
    
    var messageBuilder = new StringBuilder();
    foreach (var value in values)
    {
    	messageBuilder.AppendFormat($"{{0,{maxFieldLengths.Item1 * -1}}}\t| {{1,{maxFieldLengths.Item2 * -1}}}\t| {{2,{maxFieldLengths.Item3 * -1}}}{Environment.NewLine}",
    		value.Item1, value.Item2, value.Item3);
    }
    MessageBox.Show(messageBuilder.ToString());
