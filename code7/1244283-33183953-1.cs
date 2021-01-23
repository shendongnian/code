            var xml = GetXml(); // Your XML string
            using (var textReader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(textReader))
            {
                xmlReader.ReadToFirstElement();
                var names = xmlReader.ReadChildElementNames().ToArray();
                Console.WriteLine(string.Join("\n", names));
            }
