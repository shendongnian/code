      class Program
        {
            static void Main()
            {
                const string path = "//files//handling.meta";
                var doc = XDocument.Load(path);
    
                var items = doc.Descendants("HandlingData").Elements("Item");
                
                var query = from i in items
    
                            select new
                            {
                                HandlingName = (string)i.Element("handlingName"),
                                HandlingType = (string)i.Element("handlingType"),
                                Mass = i.Element("fMass").Attribute("value").Value
                            };
                foreach (var item in query)
                {
                    if (item.HandlingType == "HANDLING_TYPE_FLYING")
                    {
                        MessageBox.Show(item.HandlingType);
                        Console.WriteLine((item.HandlingType));
                    }
                }
            }
        }
