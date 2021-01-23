            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var result = new eSearchResult();
            try
            {
                MemoryStream XmlStream = new MemoryStream();
                XmlDocument MyDoc = new XmlDocument();
                MyDoc.Load(stream);
                XmlAttribute AddNamespace = MyDoc.CreateAttribute("xmlns");
                AddNamespace.Value = "http://tempuri.org/esearch";
                MyDoc.LastChild.Attributes.Append(AddNamespace);
                MyDoc.Save(XmlStream);
                XmlStream.Position = 0;
                result = (eSearchResult)deserializer.Deserialize(XmlStream);
            }
            catch (Exception Error)
            { }
