    using Microsoft.VisualBasic.FileIO;
    ...
    var path = @"C:\YourFile.csv";
    using (var parser = new TextFieldParser(path))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
    
        string[] line;
        while (!parser.EndOfData)
        {
            try
            {
                line = parser.ReadFields();
            }
            catch (MalformedLineException ex)
            {
                // log ex.Message
            }
        }
    }
