    var xdoc = XDocument.Load("Folder.xml");
    if (xdoc.Root != null)
    {
        var element = xdoc.Root.Elements();
        foreach (var a in element)
        {
            Console.WriteLine(a.Name);
            foreach (var item in a.Elements())
            {
                Console.WriteLine("\t" + item.Value);
            }
        }
    }
