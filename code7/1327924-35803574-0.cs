    using (TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv"))
    {
     parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        while (!parser.EndOfData)
        {
            //Process row
            string[] fields = parser.ReadFields();
            foreach (string field in fields)
            {
                //TODO: Validate field and save as needed.
            }
        }
    }
