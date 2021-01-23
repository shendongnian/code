	[Serializable()]
	public class DummyClass2 {
		[XmlElement("NodeList")] //necessary to indicate that this is an element, otherwise will be considered as array
		public TestList[] NodeList = null;
	}
	public class TestList {
		[XmlArray("Node")] //let this be array
		[XmlArrayItem("DataNode")]
		public Test[] TestItem { get; set; }
	}
	public class Test {
		private string key;
		[XmlAttribute("Key")]
		public string Key { //declare as Key instead
			get { return key; }
			set { key = value; }
		}
		private string value2; //cannot be int, must be string to accommodate both "Tom" and "30"
		[XmlAttribute("Value")]
		public string Value {  //declare as Value instead
			get { return value2; }
			set { value2 = value; }
		}
	}
