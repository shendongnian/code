    private void Parse()
    {
        using (TextFieldParser parser = new TextFieldParser("file.csv")
        {
            HasFieldsEnclosedInQuotes = true,
            Delimiters = new string[] {
                ","
            }
        })
        {
            string[] fields;
            do
            {
                fields = parser.ReadFields();
                PrintResults(fields);
            }
            while (fields != null);
        }
    }
    private void PrintResults(string[] fields)
    {
        if (fields != null)
        {
            foreach (var field in fields)
            {
                Console.Write(string.Concat("[", field, "] "));
            }
            Console.WriteLine();
        }
    }
