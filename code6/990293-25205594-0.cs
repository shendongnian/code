    XElement root = new XElement("Statements");
    
    foreach(String item in lines)
    {
        XElement xElement = XElement.Parse(item);
        root.Add(xElement);
    }
    
    sr.WriteLine(root.ToString().Trim());
