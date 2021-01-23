    public void SomeMethodInYourCodeSnippet()
    {
        string[] lines;
        using (StreamReader sr = new StreamReader(filesToProcess[x, 0]))
        {
            //Read the input file in memory and close after done
            string fileText = sr.ReadToEnd();
            lines = fileText.Split(Convert.ToString(System.Environment.NewLine).ToCharArray());
            sr.Close();  // redundant due to using, but just to be safe...
        }
        foreach (var line in lines)
        {
            string[] columnValues = GetColumnValuesFromLine(line);
            // Do whatever with your column values here...
        }
    }
    private string[] GetColumnValuesFromLine(string line)
    {
        // Split on ","
        var values = line.Split(new string [] {"\",\""}, StringSplitOptions.None);
        if (values.Count() > 0)
        {
            // Trim leading double quote from first value
            var firstValue = values[0];
            if (firstValue.Length > 0)
                values[0] = firstValue.Substring(1);
            // Trim the trailing double quote from the last value
            var lastValue = values[values.Length - 1];
            if (lastValue.Length > 0)
                values[values.Length - 1] = lastValue.Substring(0, lastValue.Length - 1);
        }
        return values;
    }
