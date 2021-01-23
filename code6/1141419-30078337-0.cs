    using (var reader = new StringReader("first,\"second, second\",\"\"\"third\"\" third\",\"\"\"fourth\"\", fourth\""))    
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(reader))
    {
        parser.Delimiters = new[] { "," };
        parser.HasFieldsEnclosedInQuotes = true;
    
        while (!parser.EndOfData)
        {
            foreach (var field in parser.ReadFields())
                Console.WriteLine(field);
        }
    }
