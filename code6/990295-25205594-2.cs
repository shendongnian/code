    int fileCount=1;
    int count = 0;
    XElement root;
    Action Save = () => root.Save(string.Format("statements{0}.xml",fileCount++));
    
    while(count < lines.Length) // or lines.Count
    try
    {
        root = new XElement("Statements");
    
        foreach(String item in lines.Skip(count))
        {
            XElement xElement = XElement.Parse(item);
            root.Add(xElement);
            count++;
        }
        Save();
    }
    catch (OutOfMemoryException)
    {
        Save();
        root = null;
        GC.Collect();
    }
