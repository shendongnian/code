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
            XmlSerializer serializer = new XmlSerializer(typeof(KeyDates));
            using (FileStream stream = new FileStream("F:\\Data\\Desktop\\ddd.xml", FileMode.Open))
            {
                object obj = serializer.Deserialize(stream);
                KeyDates keyDates = (KeyDates) obj;
                foreach (DateInfo dateInfo in keyDates.DateInfo)
                {
                    if (DateTime.Now.ToString("yyyy-MM-dd") == dateInfo.todayDate)
                    {
                        Console.WriteLine(dateInfo.todayMsg);
                    }
                }
                Console.ReadLine();
            }
        }
    }
