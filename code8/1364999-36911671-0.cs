            public static IEnumerable<XElement> GetElement(XmlReader reader, string elementName)
            {
                List<XElement> books = new List<XElement>();
                while (!reader.EOF)
                {
                    if(reader.Name != "book")
                    {
                        reader.ReadToFollowing("book");
                    }
                    if(!reader.EOF)
                    {
                        books.Add((XElement)XElement.ReadFrom(reader));
                    }
                }
                return books;
            }
  
