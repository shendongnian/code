    public class MaintenanceIndicator
    {
        public MaintenanceIndicator()
        {
            this.Parameters = new SerializableStringDictionary();
        }
        public SerializableStringDictionary Parameters { get; set; }
    }
    [XmlRoot("MaintenanceIndicators")]
    public class MaintenanceIndicators
    {
        [XmlElement("MaintenanceIndicator")]
        public List<MaintenanceIndicator> MaintenanceIndicatorList { get; set; }
    }
