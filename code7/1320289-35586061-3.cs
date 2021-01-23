    [XmlRoot("SearchResponse")]
    public sealed class SearchResponse
    {
        [XmlElement("Response", Type = typeof(Response))]
        public Response[] Responses { get; set; }
        [XmlElement("HitsCount", Type = typeof(HitsCount))]
        public HitsCount[] HitsCount { get; set; }
        [XmlArray("Hits")] // Indicates that the hits will be serialized with an outer container element named "Hits".
        [XmlArrayItem("Hit")] // Indicates that each inner entry element will be named "Hit".
        public Hit [] Hits { get; set; }
    }
