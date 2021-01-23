    var allLineFields = new List<string[]>();
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"C:\test.txt"))
    {
        parser.Delimiters = new string[] { ";" };
        parser.HasFieldsEnclosedInQuotes = false; // very useful 
        string[] lineFields;
        while ((lineFields = parser.ReadFields()) != null)
        {
            allLineFields.Add(lineFields);
        }
    }
