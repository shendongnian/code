    using System;
    using System.Xml.Linq;
    XDocument doc = XDocument.Parse(xml);
    foreach (XElement element in doc.Descendants("password"))
    {
        Console.WriteLine(element);
        // Delete your value here. Either changing the text node
        // or by removing the password node. E.g.
        element.Value = string.Empty;
    }
