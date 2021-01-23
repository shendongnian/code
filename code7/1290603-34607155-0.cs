    string str = "create myclass \"56, 'for the better or worse', 54.781\"";
    var allLineFields = new List<string[]>();
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(new StringReader(str)))
    {
        parser.Delimiters = new string[] { " " };
        parser.HasFieldsEnclosedInQuotes = true;  // important
        string[] lineFields;
        while ((lineFields = parser.ReadFields()) != null)
        {
            allLineFields.Add(lineFields);
        }
    }
