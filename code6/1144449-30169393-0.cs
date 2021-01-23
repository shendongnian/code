     XDocument document = XDocument.Load("data.xml");
    
                var texts = from t in document.Descendants("Text")
                            select new
                            {
                                AudioList = t.Attribute("audio") != null ? t.Attribute("audio").Value : string.Empty,
                                Content = t.Value,
                                Group_Name = t.Attribute("group") != null ? t.Attribute("group").Value : string.Empty
                            };
    
                var audio = from a in document.Descendants("Audio")
                            let groupName = a.Attribute("group") != null ? a.Attribute("group").Value : string.Empty
                            let fileName = a.Element("File_name") != null ? a.Element("File_name").Value : string.Empty
                            let t = texts.Where(t => t.Group_Name == groupName && t.AudioList == fileName)
                            where t.Any()
                            select new
                            {
                                Path = a.Element("Path").Value
                            };
