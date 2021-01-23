    [Serializable ()]
	[XmlRoot ( "Root" )]
	public class XmlRootClass{
		[XmlElement ( "Apple" )]
		public List<Apple> apples{
			get;
			set;
		}
		[XmlElement ( "AppleGroup " )]
		public List<AppleGroup> applegroups{
			get;
			set;
		}
	}
