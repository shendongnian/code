    public static void ShowXmlOrderedBySortByAttribute(string directory)
    {
        var xmlsWithFileName = Directory.GetFiles(directory)
                                        .Select(fileName => new { fileName, xml = XDocument.Parse(File.ReadAllText(fileName)) })
                                        .OrderBy(tuple => tuple.xml.Element("item").Element("author").Attribute("sortby").Value);
        foreach (var xml in xmlsWithFileName)
        {
            //This is C# 6 string interpolation, if you are using C# <= 5 then use string.Format, something like that:
            //Console.WriteLine($"Filename: {0}{1}Xml content:{1}", xml.fileName, Environment.NewLine);
            Console.WriteLine($"Filename: {xml.fileName}{Environment.NewLine}Xml content:{Environment.NewLine}");
            Console.WriteLine(xml.xml.ToString());
            Console.WriteLine("================");
        }
    }
