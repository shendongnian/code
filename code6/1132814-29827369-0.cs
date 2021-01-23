    var textStream = new System.IO.StringReader(text);
    List<string[]> allLineFields = new List<string[]>();
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(textStream))
    {
        parser.Delimiters = new string[] { " " };
        parser.HasFieldsEnclosedInQuotes = true; // <--- !!!
        string[] fields;
        while ((fields = parser.ReadFields()) != null)
        {
            allLineFields.Add(fields);
        }
    }
