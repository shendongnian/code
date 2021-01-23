    // Load up some xml
    string xml = "<root><child>value</child></root>";
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    
    // Get OuterXml as bytes
    byte[] bytes = Encoding.UTF8.GetBytes(doc.OuterXml);
    
    // bytes to hex values
    StringBuilder buffer = new StringBuilder();
    
    foreach (byte b in bytes)
        buffer.AppendFormat("{0:X2}", b);
    
    // Results
    Console.WriteLine(buffer);
