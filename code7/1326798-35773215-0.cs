    XmlDocument xDoc = new XmlDocument();
    string path = @"C:\Folder";
       foreach (string file in Directory.EnumerateFiles(path, "*.xml"))
       {
          xDoc.Load(Path.Combine(Directory.GetCurrentDirectory(), file));
          XmlNamespaceManager mgr = new XmlNamespaceManager(xDoc.NameTable);
          mgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
          xDoc.LoadXml(xDoc.DocumentElement.SelectSingleNode("soap:Body", mgr).ChildNodes[0].OuterXml);
          doc.Save("E:\\" + file);
    }
