    string LINES = @"
        ""A001"";""RT:This is a tweet""; ""http://www.whatever.com/test/module&amp;one""
        ""A001"";""RT: Test1 ; Test2"";""test.com"";   
    ";
    using (var sr = new StringReader(LINES))
    {
        using (var parser = new TextFieldParser(sr))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(";");
            parser.TrimWhiteSpace = true;
            parser.HasFieldsEnclosedInQuotes = true;
    
            while (parser.PeekChars(1) != null)
            {
                var cleanFieldRowCells = parser.ReadFields().Select(
                    f => f.Trim(new[] { ' ', '"' })).ToArray();
                Console.WriteLine("New Line");
                for (int i = 0; i < cleanFieldRowCells.Length; ++i)
                {
                    Console.WriteLine(
                        "Field[{0}]: = [{1}]", i, cleanFieldRowCells[i]
                    );
                }
                Console.WriteLine("{0}", new string('=', 40));
            }
        }
    }
