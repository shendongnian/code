	public interface ISomething
	{
		string Name { get; set; }
		object Value { get; }
		Type ValueType { get; }
	}
	
	public class Something<T> : ISomething
	{
		public string Name { get; set; }
		public T Value { get; set; }
		object ISomething.Value { get { return Value; } }
		Type ISomething.ValueType { get { return typeof(T); } }
		
		public Something(string name, T value)
		{
			Name = name;
			Value = value;
		}
	}
