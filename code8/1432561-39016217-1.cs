    public class TypeToSerialize
    {
        [XmlArray("myThings")]
        [XmlArrayItem("This")]
        public List<string> myThingsToSerialize { get; set; }
        [XmlIgnore]
        public List<System.Web.Mvc.SelectListItem> MyThings
        {
            get { return this.myThingsToSerialize.Select(x => new SelectListItem {Text = x, Value = x}).ToList(); }
        }
    }
	
