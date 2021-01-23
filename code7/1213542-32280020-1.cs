    static void Main(string[] args)
    {
        XElement xml = XElement.Load(@"c:\Temp\index.xml");
        var items = xml.Descendants("name");
        foreach (var element in items)
        {
            Console.WriteLine(element.Value);
        }
        Console.WriteLine("Finished");
        Console.ReadLine();
    }
