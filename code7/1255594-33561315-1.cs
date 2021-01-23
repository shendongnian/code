    [Serializable ()]
    public class Apple{
    	[XmlAttribute("Clr")]
		public string color{
			get;set;
		}
    
    	[XmlText]
		public string Text{
			get;set;
		} 
    }
