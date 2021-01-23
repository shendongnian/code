	[Serializable()]
	public class NodeList {
		[XmlArray("Node")]
		[XmlArrayItem("DataNode")]
		public Test[] Nodes;
	}
	public class Test {
		[XmlAttribute]
		public string Name { get; set; }
		public int Age { get; set; }
	}
