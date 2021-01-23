            var rootElement = XElement.Parse(xmlString); // xmlString is //response.Content
            var set = new DataSet();
            var setElement = rootElement.DescendantsAndSelf().Where(e => e.Name.LocalName == "NewDataSet").FirstOrDefault();
            if (setElement != null)
            {
                using (var reader = setElement.CreateReader())
                {
                    set.ReadXml(reader, XmlReadMode.Auto);
                }
            }
