    public class ReportSpec{
        [System.Xml.Serialization.XmlElementAttribute("Report")]
        public List<ReportsHolder> ReportsList { get; set; }
    
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Version { get; set; }
    
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Username { get; set; }
    
        public ReportSpec()
        {
            this.ReportsList = new List<ReportsHolder>();
        }    
    }
