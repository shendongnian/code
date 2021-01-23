    [Serializable]
    [XmlRoot("details")]
    public class BulkProjectData
    {
        public BulkProjectData()
        {
            // Not a list
            ProjectResearches = new ProjectResearchOutputs();
        }
        [XmlElement("projectName")]
        public string Name { get; set; }
        [XmlElement("uniqueID")]
        public string ProjectUniqueId { get; set; }
        [XmlElement("researchOutputList")]
        public ProjectResearchOutputs ProjectResearches { get; set; } 
    }
