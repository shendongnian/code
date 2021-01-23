    var doc = XDocument.Parse(s);
    Dictionary<string, string> ConfigItems;
    ConfigItems = doc.Descendants("TestTable")
      .ToDictionary(v => v.Element("Tag").Value,
                    v => v.Element("FName").Value);
    var item = ConfigItems["tag3"];
    Console.WriteLine(item); // "t3"
