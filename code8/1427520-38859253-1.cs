    public class PlacesApiQueryResponse
    {
        public List<object> html_attributions { get; set; }
	
        // attribute to tell XmlSerializer how are the item-elements named
        [XmlArrayItem("result")]
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
