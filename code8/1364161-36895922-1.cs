      [XmlRoot("response")]
      public class XMLStat
      {
        public int responsecode;
        public int count;
        [XmlElement("statistics")]
        public List<StatElement> statistics;
      }
      public class StatElement
      {
        public string id;
        public string msisdn;
      }
