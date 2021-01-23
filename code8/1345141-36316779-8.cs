        static void Main(string[] args)
        {
            Dictionary<string, BaseClass> items = new Dictionary<string, BaseClass>();
            items.Add("1", new concreteClass1() { id = "1", prop1 = "blah1" });
            items.Add("11", new concreteClass1() { id = "11", prop1 = "blah11" });
            // this should work too....
            items.Add("999", new concreteClass2() { id = "999", prop1 = "blah999" });
            items.Add("888", new concreteClass2() { id = "888", prop1 = "blah888" });
            //Serialize(items);
            var serializer = new DataContractSerializer(items.GetType());
            string xmlString = string.Empty;
            try
            {
                using (var sw = new StringWriter())
                {
                    using (var writer = new XmlTextWriter(sw))
                    {
                        writer.Formatting = System.Xml.Formatting.Indented;
                        serializer.WriteObject(writer, items);
                        writer.Flush();
                        xmlString = sw.ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
