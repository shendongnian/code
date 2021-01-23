    public class FieldOptions
	{
		public string save_to { get; set; }
		public string size { get; set; }
		public string description { get; set; }
	}
	public class Field
	{
		public string label { get; set; }
		public string field_type { get; set; }
		public bool required { get; set; }
		public FieldOptions field_options { get; set; }
		public string cid { get; set; }
	}
	public class RootObject
	{
		public List<Field> fields { get; set; }
	}
