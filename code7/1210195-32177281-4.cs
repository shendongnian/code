	public interface ISomething
	{
		string Name { get; set; }
		object Value { get; }  
	}
	
	public class Something<T> : ISomething
	{
		public string Name { get; set; }
		public T Value { get; set; }
		object ISomething.Value { get { return Value; } }
		
		public Something(string name, T value)
		{
			Name = name;
			Value = value;
		}
	}
