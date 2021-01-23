    IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
    
                string fileName = "YourFileName.xml";
                XDocument document;
    
                if (file.FileExists(fileName))
                    using (IsolatedStorageFileStream stream = file.OpenFile(fileName, System.IO.FileMode.Open))
                    {
                        document = XDocument.Load(stream);
                    }
                else
                    document = XDocument.Load(fileName);
    
                var root = new XElement("player");
               var name = new XElement("name", "1233");
                var high = new XElement("high", "1233");
                var current = new XElement("current ", "1233");
                var played = new XElement("played ", "1233");
    
                root.Add(name, high, current,played);
                document.Root.Add(root);
    
    
    
                using (IsolatedStorageFileStream stream = file.CreateFile(fileName))
                {
                    document.Save(stream);
                }
