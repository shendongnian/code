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
                KeyDates keyDates = (KeyDates)serializer.Deserialize(stream);
                foreach (DateInfo item in keyDates.DateInfo)
                {
                    if (DateTime.Now.ToString("yyyy-MM-dd") == item.todayDate)
                    {
                        Console.WriteLine(item.todayMsg);
                    }
                }
                Console.ReadLine();
            }
        }
    }
