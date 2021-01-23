    public class FrameSection
    {
        [XmlAttribute]
        public string Name { get; set; }
        public string[] StartSection { get; set; }
        [XmlAttribute]
        public string SerializableStartSection
        {
            get
            {
                return string.Join(",", StartSection);
            }
            set
            {
                StartSection = value.Split(',');
            }
        }
    }
