    static void Main(string[] args)
        {
            string xml = File.ReadAllText(path of the file);
            Param p = DeserializeFromXml<Param>(xml);
        }
        public static T DeserializeFromXml<T>(string xml)
        {
            try
            {
                T result;
                XmlSerializer ser = new XmlSerializer(typeof(T));
                using (TextReader tr = new StringReader(xml))
                {
                    result = (T)ser.Deserialize(tr);
                }
                return result;
            }
            catch { throw; }
        }
    }
    [Serializable]
    [XmlRoot(Namespace = "", ElementName = "param")]
    public class Param
    {
        [XmlArray("professors")]
        public List<professor> Professor { get; set; }
        [XmlArray("courses")]
        public List<course> Course { get; set; }
    }
    public class professor
    {
       [XmlAttribute("id")]
        public int id { get; set; }
       [XmlAttribute("name")]
        public string name { get; set; }
        public professor() { }
    }
    public class course
    {
         [XmlAttribute("id")]
        public int id { get; set; }
           [XmlAttribute("name")]
        public string name { get; set; }
        public course() { }
    }
