    [Serializable ()]
        public class AppleGroup{
    	[XmlAttribute("Clr")]
		public string color{
			get;set;
		}
    
    	[XmlElement ( "Apple" )]
		public List<Apple> apples{
			get;
			set;
		} 
    }
