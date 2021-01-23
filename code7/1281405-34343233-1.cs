    string fileName = "person.xml";
    using (IsolatedStorageFile isoManager = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (isoManager.FileExists(fileName))
        {
            XDocument collection = XDocument.Load(fileName);
            XElement person = new XElement("user",
                new XElement("id", "someid"),
                new XElement("name", "someName"),
                new XElement("info", "someInfo"));
            collection.Element("root").Add(person);
            using (IsolatedStorageFileStream fileWriter = isoManager.OpenFile(fileName, FileMode.Open))
            {
               using (XmlWriter writer = XmlWriter.Create(fileWriter))
               {
                   collection.WriteTo(writer);
               }
            }
        }
        else
        {
            XDeclaration declaration = new XDeclaration("1.0", "utf-8", "yes");
            XDocument collection = new XDocument(declaration);
            XElement person = new XElement("root",
               new XElement("user",
               new XElement("id", "someid"),
               new XElement("name", "someName"),
               new XElement("info", "someInfo")));
            collection.Add(person);
            using (IsolatedStorageFileStream fileWriter = isoManager.CreateFile(fileName))
            {
                using (XmlWriter writer = XmlWriter.Create(fileWriter))
                {
                    collection.WriteTo(writer);
                }
            }
        }
    }
