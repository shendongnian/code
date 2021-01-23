       public class Row
        {
            private static XmlTextReader reader = null;
            public int Id { get; set; }
            public string name { get; set; }
            public DateTime startDate { get; set; }
            public Row() { }
            public Row(TextReader sReader)
            {
                reader = new XmlTextReader(sReader); //can be filename instead of stringreader
            }
            public Row Get(string elementName)
            {
                Row results = null;
                if (!reader.EOF)
                {
                    if (reader.Name != elementName)
                    {
                        reader.ReadToFollowing(elementName);
                    }
                    if (!reader.EOF)
                    {
                        XElement newRow = (XElement)XElement.ReadFrom(reader);
                        results = new Row() { Id = (int)newRow.Attribute("Id"), name = (string)newRow.Attribute("Name"), startDate = (DateTime)newRow.Attribute("StartDate") };
                    }
                }
                return results;
            }
        }​
