	public class DataValue
	{
		[XmlAttribute("status")]
		public int Status { get; set; }
        [XmlText]
		public float Value { get; set; }
	}
