    void Main()
    {
        List<string[]> lines = new List<string[]>();
        
        TextFieldParser CSVFile1 = new TextFieldParser(@"g:\test\test.csv");
        CSVFile1.SetDelimiters(",");
        
        //Loop through the data and create a list.  Each entry in the list
        //is a string array.  This method may be impractical for very large 
        //files.
        while (!CSVFile1.EndOfData)
        {
            lines.Add(CSVFile1.ReadFields());
        }
        
        //Create a format string using the length of the longest string in each column
        string formatString = createFormatString(lines);
        
        //Loop through all the lines and write them to the console.
        foreach (var csvLine in lines)
        {
            Console.WriteLine(formatString, csvLine);
        }
    }
    
    //Create a format string based on the number of columns and the maximum
    // size of each column
    private string createFormatString(List<string[]> lines)
    {
        var sb = new StringBuilder();
        
        //Use the first array to get the number of columns.  They should all be the same
        int numberOfColumns = lines[0].Length;
        
        //Loop through the number of columns and find the max length and append to the format string
        for (int i = 0; i < numberOfColumns; i++)
        {
            int maxColumnWidth = lines.Select(l => l[i].Length).Max();
            sb.AppendFormat("{{{0}, -{1}}}  ", i, maxColumnWidth);
        }
        
        return sb.ToString();
    }
