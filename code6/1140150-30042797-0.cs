	public interface GenericMyStruct
	{
		string Key { get; set; }
		object ObjectValue { get; }
	}
	public class MyStruct<T> : GenericMyStruct
	{
		public string Key { get; set; }
		public T Value { get; set; }
		public object ObjectValue { get { return (object)Value; } }
	}
