    TextFieldParser textFieldParser = new TextFieldParser(@"E:\Project.csv");
    textFieldParser.TextFieldType = FieldType.Delimited;
    textFieldParser.SetDelimiters(",");
    while (!textFieldParser.EndOfData)
    {
        string[] values = textFieldParser.ReadFields();
        Console.WriteLine(string.Join("---", values));//printing the row
    }
    textFieldParser.Close();
