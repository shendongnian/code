            string input = System.IO.File.ReadAllText(PATH_TO_YOUR_XML_FILE); //this can be replaced with any func giving string
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Events));
            var doc = XDocument.Parse(input);
            using (var reader = doc.Root.CreateReader())
            {
                return (Events)xmlSerializer.Deserialize(reader);
            }
