    [Serializable]
    public class School
    {
        [XmlElement("gsId")] //Custom property name
        public string GSId { get; set; } //The same property name
        public string name { get; set; }
        public string type { get; set; }
        public string gradeRange { get; set; }
        [XmlElement("schoolType")] //Enum declaration
        public SchoolType SchoolType { get; set; }
    }
