    using (var stream = new MemoryStream())
    {
        var input = "A, B, C, D\r\n";
        input += "Peter,Jill,Siobhan,Nathan\r\n";
        var bytes = System.Text.Encoding.Default.GetBytes(input);
        stream.Write(bytes, 0, bytes.Length);
        stream.Seek(0, SeekOrigin.Begin);
        using (var parser = new TextFieldParser(stream))
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
    }
