    [Serializable]
    [XmlRoot("rows")]
    public class Rows
    {
        [XmlElement("row")]
        public List<int> Elements { get; set; } 
    }
    public static void SerializeOnScreen()
    {
        Rows numbers = new Rows();
        numbers.Elements = new List<int>() { 1, 2, 3, 4, 5 };
        var serializer = new XmlSerializer(typeof(Rows));
        using (var stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, numbers);
            Console.Write(stringWriter.ToString());
        }
    }
