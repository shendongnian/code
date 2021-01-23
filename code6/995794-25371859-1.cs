    public class Service
    {
        private List<Link> _links;
        [XmlIgnore]
        public Link ServiceTypeUrl
        {
            get { return Links.FirstOrDefault(l => l.Rel == "service_type"); }
            set
            {
                var tempLink = value;
                tempLink.Rel = "service_type";
                Links.RemoveAll(l => l.Rel == tempLink.Rel); // prevent duplicate rel
                Links.Add(tempLink);
            }
        }
        [XmlIgnore]
        public Link Url
        {
            get { return Links.FirstOrDefault(l => l.Rel == "self"); }
            set
            {
                var tempLink = value;
                tempLink.Rel = "self";
                Links.RemoveAll(l => l.Rel == tempLink.Rel); // prevent duplicate rel
                Links.Add(tempLink);
            }
        }
        [XmlElement("link")]
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }
        [XmlArray("supported_versions")]
        [XmlArrayItem("supported_version")]
        public List<SupportedVersion> SupportedVersions { get; set; }
    }
