    public static class EMailAlerts
    {
        static XmlSerializer   XML = new XmlSerializer(typeof(List<EMailAlert>));
        public static List<EMailAlert> Alerts { get; private set; }
        public static void Save(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                XML.Serialize(stream, Alerts);
            }
        }
        public static void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Alerts = new List<EMailAlert>();
            }
            else
            {
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    Alerts = (List<EMailAlert>)XML.Deserialize(stream);
                }
            }
        }
    }
    public class EMailAlert
    {
        public string h1 { get; set; }
        public string body { get; set; }
        public string idList { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EMailAlerts.LoadFromFile("tmp.xml");
            EMailAlerts.Alerts.Add(new EMailAlert{ body="foo"});
            EMailAlerts.Save("tmp.xml"); 
        }
    }
