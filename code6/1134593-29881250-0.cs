    private static void ToXml(List<int> list)
            {
                var doc = new XDocument(new XElement("List", list.Select(x =>
                    new XElement("itemValue", x))));
                doc.Save("test.xml");
            }
