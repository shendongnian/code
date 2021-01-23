    string xml = "abc def ghi blabla horse 123 jakljd alj ldkfj s;aljf kljf sdlkj flskdjflskdjlf lskjddhcn guffy";
    Dictionary<string, string> substitutions = new Dictionary<string, string> 
    { 
        {@"(?<=abc\s).+(?=\sghi)", "AAA"},
        {@"(?<=kljf\s).+(?=\sflskdjflskdjlf)", "BBB"}
    };
    foreach (KeyValuePair<string, string> entry in substitutions)
    {
        xml = Regex.Replace(xml, entry.Key, entry.Value);
        Console.WriteLine(xml);
    }
