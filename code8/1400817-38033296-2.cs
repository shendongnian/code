	public enum TypesOfFeature // The enum of features
	{
		One = 1,
		Two = 2,
		Three = 3
        ... // etc.
	}
	public class Feature // The class to map to a table in your DB
	{
		public int Id { get; set; }
		public TypesOfFeature Type { get; set; }
	}
