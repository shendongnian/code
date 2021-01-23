    using Microsoft.VisualBasic.FileIO;
    ....
    var str = "123-234;FOO-456;45-67;FOO-FOO;890;FOO-123;11-22;123;123;44-55;098-567;890;123-FOO;";
    var csv_parser = new TextFieldParser(new StringReader(str));
    csv_parser.HasFieldsEnclosedInQuotes = false;   // Fields are not enclosed with quotes
    csv_parser.SetDelimiters(";");                  // Setting delimiter
    string[] fields;
    var range_fields = new List<string>();
    var integer_fields = new List<string>();
    while (!csv_parser.EndOfData)
    {
        fields = csv_parser.ReadFields();
        foreach (var field in fields)
        {
            if (!string.IsNullOrWhiteSpace(field) && field.All(x => Char.IsDigit(x)))
            {
                integer_fields.Add(field);
                Console.WriteLine(string.Format("Intger field: {0}", field));
            }
            else if (!string.IsNullOrWhiteSpace(field) && Regex.IsMatch(field, @"\d+-\d+"))
            {
                 range_fields.Add(field);
                 Console.WriteLine(string.Format("Range field: {0}", field));
            }
        }
    }
    csv_parser.Close();
