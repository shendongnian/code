    string fileName = "collections.xml";
    using (IsolatedStorageFile isoManager = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (isoManager.FileExists(fileName))
        {
            XDocument document;
            using (IsolatedStorageFileStream reader = isoManager.OpenFile(fileName, FileMode.Open))
            {
                document = XDocument.Load(reader);
            }
            foreach (XElement a in document.Descendants("user"))
            {
                 Person temp = new Person((int)a.Element("id"), (string)a.Element("info"), (string)a.Element("name"));
                 lPerson.Add(temp);
                 lPerson.nbPerson++;
            }
        }
    }
