        private void Test()
        {
            var obj = new PTH()
            {
                Account = new Account() { UserName = "bob's", Password = "burgers" },
                ChartNames = Enumerable.Range(1, 3).Select(x => new ChartName() { Id = x, name = "Name_" + x.ToString() }).ToArray()
            };
            var xml = SerializeXML(obj);
            var objDeserialized = DeserializeXML<PTH>(xml);
            var chartsToChange = objDeserialized.ChartNames.Where(x => x.Id == 1).ToList();
            foreach (var chart in chartsToChange)
            {
                chart.name = "new name";
            }
            var backToXML = SerializeXML(objDeserialized);
        }
        public static string SerializeXML<T>(T obj)
        {
            var izer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(stringWriter))
                {
                    izer.Serialize(xmlWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }
        public static T DeserializeXML<T>(string xml)
        {
            var izer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(xml))
            {
                using (var xmlReader = new XmlTextReader(stringReader))
                {
                    return (T)izer.Deserialize(xmlReader);
                }
            }
        }
        public class PTH
        {
            public Account Account { get; set; }
            public ChartName[] ChartNames { get; set; }
        }
        public class Account
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        public class ChartName
        {
            public int Id { get; set; }
            public string name { get; set; }
        }
