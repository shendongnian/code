    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Example));
                using (XmlReader reader = XmlReader.Create("test.xml"))
                {
                    Example example = (Example)serializer.Deserialize(reader);
                    Console.WriteLine(example.Id.ToString());
                    Console.WriteLine(example.Messages.Count.ToString());
                    Console.WriteLine(example.Messages[0].Words);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.ReadLine();
        }
        
        [XmlRoot("example")]
        public class Example
        {
            [XmlElement("id")]
            public int Id
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }
            }
            private int id;
            [XmlArray("messages")]
            [XmlArrayItem("message", typeof(Message))]
            public List<Message> Messages
            {
                get
                {
                    return messages;
                }
                set
                {
                    messages = value;
                }
            }
            private List<Message> messages;
        }
        [XmlRoot("message")]
        public class Message
        {
            [XmlElement("words")]
            public string Words { get; set; }
        }
    
