    [DataContract(Name = "content", Namespace = "")]
    public class MemberListItem
    {
        // The following properties are "known" - common to all IPublishedContent
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "contentType")]
        public IContentType ContentType { get; set; }
        // This one contains a list of all other custom properties.
        private Dictionary<string, string> properties;
        [DataMember(Name = "properties")]
        public IDictionary<string, string> Properties
        {
            get
            {
                if (properties == null)
                    properties = new Dictionary<string, string>();
                return properties;
            }
        }
    }
