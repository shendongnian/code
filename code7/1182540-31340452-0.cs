    XElement root = XElement.Load("file.xml");
    // look for a File1
    var file1 = root.Descendants()
        .Where(elem => elem.Attribute("Name").Value == "File1")
        .Single();
    // go 2 levels back
    var mainFolder = file1.Parent.Parent;
    // display each folder
    foreach (var folder in mainFolder.Elements())
    {
        Console.WriteLine(folder.Attribute("Name").Value);
        // display each file
        foreach (var file in folder.Elements())
        {
            Console.WriteLine("  " + file.Attribute("Name").Value);
        }
        Console.WriteLine();
    }
