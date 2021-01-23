    CustomXmlPart customXmlPart1 = mainPart.CustomXmlParts.FirstOrDefault();
    System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(customXmlPart1.GetStream(System.IO.FileMode.Create),System.Text.Encoding.UTF8);
    
    writer.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Root>\n");
    foreach (var val in values) // values is a Dictionary<string,string> of element tag name and element value
    {
        writer.WriteRaw( "<" + val.Key + ">" + val.Value + "</" + val.Key + ">\n");
    }
    writer.WriteRaw( "</Root>");
    writer.Flush();
