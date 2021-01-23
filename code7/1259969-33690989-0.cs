    var allLineFields = new List<string[]>();
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(new StringReader(str)))
    {
        parser.Delimiters = new string[] { "," };
        parser.HasFieldsEnclosedInQuotes = true; // <--- !!!
        string[] lineFields;
        while ((lineFields = parser.ReadFields()) != null)
        {
            allLineFields.Add(lineFields);
        }
    }
