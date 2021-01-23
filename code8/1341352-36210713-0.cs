    StringReader sr = new StringReader("Data1,6.5,\"Data3,\"\"MoreData\"\"\"");
    using (var parser = new TextFieldParser(sr))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true;
        while (!parser.EndOfData)
        {
            Console.WriteLine("Line:");
            var fields = parser.ReadFields();
            foreach (var field in fields)
            {
                Console.WriteLine("\tField: " + field);
            }
        }
    }
