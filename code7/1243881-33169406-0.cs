	public class Dog
	{
		public string Name { get; set; }
	}
	public class DogMediaTypeFormatter : JsonMediaTypeFormatter
	{
		public override bool CanReadType(Type type)
		{
			return type == typeof (Dog);
		}
	}
