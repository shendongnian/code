    string str = "-p \"This is a string \"\"with quotes\"\"\" d:\\1.txt \"d:\\some folder\\1.out\"";
    var allLineFields = new List<string[]>();
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(new StringReader(str)))
    {
        parser.Delimiters = new string[] { " " };
        parser.HasFieldsEnclosedInQuotes = true; // <--- !!!
        string[] lineFields;
        while ((lineFields = parser.ReadFields()) != null)
        {
            allLineFields.Add(lineFields);
        }
    }
