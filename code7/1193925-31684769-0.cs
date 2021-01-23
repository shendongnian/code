    public class Program
    {
        static void Main(string[] args)
        {
            var data = new MyConfig[2];
            for (int i = 0; i < 2; i++)
            {
                data[i] = new MyConfig { Name = "Name" + i };
                data[i].Properties = new MyConfigAttribute[]
                {
                    new MyConfigAttribute { Name = "Property Name " + i, Value = "Property Value " + i },
                    new MyConfigAttribute { Name = "2nd Property Name " + i, Value = "2nd Property Value " + i },
                };
            }
            var serializer = new XmlSerializer(typeof(MyConfig[]));
            using (StreamWriter tw = File.CreateText(@"c:\temp\myconfig.xml"))
            {
                serializer.Serialize(tw, data);
            }
            using (StreamReader tw = File.OpenText(@"c:\temp\myconfig.xml"))
            {
                var readBack = serializer.Deserialize(tw);
            }
            Console.ReadLine();
        }
        [XmlRoot("MY_CONFIG")]
        public class MyConfig
        {
            [XmlElement("NAME")]
            public string Name { get; set; }
            [XmlArray]
            [XmlArrayItem(typeof(MyConfigAttribute))]
            public MyConfigAttribute[] Properties { get; set; }
        }
        [XmlRoot("MY_CONFIG_ATTRIBUTE")]
        public class MyConfigAttribute
        {
            [XmlElement("ATTRIBUTE_NAME")]
            public string Name { get; set; }
            [XmlElement("ATTRIBUTE_VALUE")]
            public string Value { get; set; }
        }
    }
