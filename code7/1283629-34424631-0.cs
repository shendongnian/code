    public class MaintenanceIndicator
    {
        public MaintenanceIndicator()
        {
            this.Parameters = new List<SerializableStringDictionary>();
        }
        [XmlElement]
        public List<SerializableStringDictionary> Parameters { get; set; }
    }
