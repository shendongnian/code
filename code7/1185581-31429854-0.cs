    StringBuilder sb = newStringBuilder();
    using (FileStream reader = File.OpenRead(@"Data.csv")) // mind the encoding - UTF8
            using (TextFieldParser parser = new TextFieldParser(reader))
            {
                parser.TrimWhiteSpace = true; // if you want
                parser.Delimiters = new[] { "," };
                parser.HasFieldsEnclosedInQuotes = true;
                while (!parser.EndOfData)
                {
                    string[] line = parser.ReadFields();
                    List<string> li = line.SelectMany(x => x.Split(',')).ToList();
                    sb.AppendLine(String.Format("Name: {0}, ID: {1}", li[0],li[1]));
                }
            }
    MessageBox.Show(sb.ToString());
