	[Serializable]
	public class Model
	{
		[XmlElement("Id")]
		public int Id { get; set; }
		[XmlArray("Sections")]
		public List<Section> Sections { get; set; }
	}
