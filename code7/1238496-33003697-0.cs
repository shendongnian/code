    string t = "\"test\",645,23.4,42,\"13,13,14\",\"test\"";
    StringReader sr = new StringReader(t);
    TextFieldParser tp = new TextFieldParser(sr);
    tp.Delimiters = new string[] {","};
    tp.HasFieldsEnclosedInQuotes = true;
    
    string[] result = tp.ReadFields();
    foreach(string s in result)
       Console.WriteLine(s);
