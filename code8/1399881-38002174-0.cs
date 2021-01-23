     static void Main(string[] args)
        {
            var xml = File.ReadAllText(@"test.xml");
            xml = System.Net.WebUtility.HtmlDecode(xml);
            XmlSerializer serializer = new XmlSerializer(typeof(Cluster));
            using (var reader = new StringReader(xml))
            {
                var info = (Cluster)serializer.Deserialize(reader);
            }
            Console.Read();
        }
