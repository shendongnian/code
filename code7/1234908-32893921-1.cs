    class Program
    {
    
        static void Main(string[] args)
        {
            // Just store this as a string for thie example
            string xml = "<Root><XMLExamples><XMLExample><Date>1997-10-23T00:00:00</Date></XMLExample><XMLExample><Date>2001-10-23T00:00:00</Date></XMLExample></XMLExamples></Root>";
            Root xmlData;
            XmlSerializer deserializer = new XmlSerializer(typeof(Root));
    
            // Deserialize to Root object
            using (var reader = new StringReader(xml))
            {
                object obj = deserializer.Deserialize(reader);
                xmlData = (Root)obj;
            }
    
            xmlData.XMLExamples = xmlData.XMLExamples.OrderByDescending(x => x.Date).ToList();
    
            // Now Serialize the sorted object
            string sortedXml = string.Empty;
    
            var serializer = new XmlSerializer(typeof(Root));
    
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, xmlData);
    
                sortedXml = writer.ToString();
            }
    
            Console.WriteLine(sortedXml);
    
            Console.ReadLine();
        }
    }
