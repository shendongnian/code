    public static void ShowXmlOrderedBySortByAttribute(string directory)
    {
        var xmlsWithFileName = Directory.GetFiles(directory)
                                        .Select(fileName => new { fileName, xml = XDocument.Parse(File.ReadAllText(fileName)) })
                                        .OrderBy(tuple => tuple.xml.Element("item").Element("author").Attribute("sortby").Value);
        
        foreach (var xml in xmlsWithFileName)
        {
            Console.WriteLine($"Filename: {xml.fileName}{Environment.NewLine}Xml content:{Environment.NewLine}");
            Console.WriteLine(xml.xml.ToString());
            Console.WriteLine("================");
        }
    }
