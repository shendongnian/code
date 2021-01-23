    class Program
	{
		static void Main(string[] args)
		{
			Modifiable<int> modInt = new Modifiable<int>(5);
			modInt.OnModified += (old, val) => { Console.WriteLine("Modified from {0} to {1}", old, val); };
			modInt.SetValue(4);
			Console.ReadLine();
		}
	}
	class Modifiable<T>
	{
		private T _value;
		public T Value { get { return _value; } }
		public event Action<T,T> OnModified;
		public void SetValue(T newValue)
		{
			var oldVal = _value;
			_value = newValue;
			OnModified?.Invoke(oldVal, _value);
		}
		public Modifiable(T value)
		{
			_value = value;
		}
		public override string ToString()
		{
			return Value?.ToString();
		}
	}
