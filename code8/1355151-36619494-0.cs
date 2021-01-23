    List<string[]> allLineFields = new List<string[]>();
    string sampleLine = @"street,""test,format"", casio";
    using (TextReader sr = new StringReader(sampleLine))
    using (TextFieldParser parser = new TextFieldParser(sr))
    {
        parser.HasFieldsEnclosedInQuotes = true;
        parser.Delimiters = new[] { "," };
        while (!parser.EndOfData)
        {
            string[] fields = parser.ReadFields();
            allLineFields.Add(fields);
        }
    }
