      using (TextFieldParser parser = new TextFieldParser(Stream))
      {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        while (!parser.EndOfData)
        {
          string[] fields = parser.ReadFields();
          foreach (string field in fields)
          {
             // Do your stuff here ...
          }
        }
      }
