    public class KeyDates
    {
        [XmlElement("DateInfo")]
        public List<DateInfo> DateInfo { get; set; }
    }
    public class DateInfo
    {
        [XmlElement("todayDate")]
        public string todayDate { get; set; }
        [XmlElement("todayMsg")]
        public string todayMsg { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(KeyDates));
            using (FileStream Stream = new FileStream("F:\\Data\\Desktop\\ddd.xml", FileMode.Open))
            {
                object obj = Serializer.Deserialize(Stream);
                KeyDates KeyDates = (KeyDates) obj;
                foreach (DateInfo DateInfo in KeyDates.DateInfo)
                {
                    if (DateTime.Now.ToString("yyyy-MM-dd") == DateInfo.todayDate)
                    {
                        Console.WriteLine(DateInfo.todayMsg);
                    }
                }
                Console.ReadLine();
            }
        }
    }
