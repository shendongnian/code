    using (TextFieldParser reader = new TextFieldParser(@"c:\yourpath\file.csv"))
    {
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        while (!reader.EndOfData) 
        {
            //Processing row
            string[] fields = reader.ReadFields();
            // now fields contains 4 elements
        }
    }
