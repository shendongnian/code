    var allLineFields = new List<string[]>();
    string sampleText = "Method,\"value1,value2\"";
    var reader = new System.IO.StringReader(sampleText);
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(reader))
    {
        parser.Delimiters = new string[] { "," };
        parser.HasFieldsEnclosedInQuotes = true; // <--- !!!
        string[] fields;
        while ((fields = parser.ReadFields()) != null)
        {
            allLineFields.Add(fields);
        }
    }
