        static IEnumerable<XElement> StreamCustomerItem(string uri)
       {
        using (XmlReader reader = XmlReader.Create(uri))
        {
            XElement name = null;
            XElement item = null;
    
            reader.MoveToContent();
    
            // Parse the file, save header information when encountered, and yield the
            // Item XElement objects as they are created.
    
            // loop through Customer elements
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element
                    && reader.Name == "Customer")
                {
                    // move to Name element
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element &&
                            reader.Name == "Name")
                        {
                            name = XElement.ReadFrom(reader) as XElement;
                            break;
                        }
                    }
    
                    // loop through Item elements
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.EndElement)
                            break;
                        if (reader.NodeType == XmlNodeType.Element
                            && reader.Name == "Item")
                        {
                            item = XElement.ReadFrom(reader) as XElement;
                            if (item != null)
                            {
                                XElement tempRoot = new XElement("Root",
                                    new XElement(name)
                                );
                                tempRoot.Add(item);
                                yield return item;
                            }
                        }
                    }
                }
            }
        }
    }
    
    static void Main(string[] args)
    {
        XStreamingElement root = new XStreamingElement("Root",
            from el in StreamCustomerItem("Source.xml")
            select new XElement("Item",
                new XElement("Customer", (string)el.Parent.Element("Name")),
                new XElement(el.Element("Key"))
            )
        );
        root.Save("Test.xml");
        Console.WriteLine(File.ReadAllText("Test.xml"));
    }
