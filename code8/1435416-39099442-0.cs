    XmlDocument doc = new XmlDocument();
    doc.Load("persons.xml");
    
    XmlNode currNode = doc.DocumentElement.FirstChild;
    Console.WriteLine("First person...");
    Console.WriteLine(currNode.OuterXml);
    
    XmlNode nextNode = currNode.NextSibling;
    Console.WriteLine("\r\nSecond person...");
    Console.WriteLine(nextNode.OuterXml); 
