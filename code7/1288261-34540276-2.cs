    public static void ShowXmlOrderedBySortByAttribute(string directory)
    {
        var xmls = Directory.GetFiles(directory)
                            .Select(file => new { file, xml = XDocument.Parse(File.ReadAllText(file)) })
                            .OrderBy(tuple => tuple.xml.Element("item").Element("author").Attribute("sortby").Value);
        foreach (var xml in xmls)
        {
            Console.WriteLine($"Filename: {xml.file}{Environment.NewLine}Xml content:{Environment.NewLine}");
            Console.WriteLine(xml.xml.ToString());
            Console.WriteLine("================");
        }
    }
