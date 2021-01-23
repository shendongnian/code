    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Sample.xml"))
            {
                var serializer = new XmlSerializer(typeof(TemplateSetting));
                var templateSetting = (TemplateSetting)serializer.Deserialize(reader);
            }
        }
    }
    [XmlRoot]
    public class TemplateSetting
    {
        public string DecimalSeparator { get; set; }
        public string ThousandSeparator { get; set; }
        public string DateSeparator { get; set; }
        public string TimeSeparator { get; set; }
    }
