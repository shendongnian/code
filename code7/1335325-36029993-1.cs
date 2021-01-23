	void Main()
	{
		var idToFunc = new Dictionary<int, object>();
		idToFunc.Add(1, new DeSerializeableElement<int>(() => 1));
	
		Console.WriteLine(GetList<int>(((DeSerializeableElement<int>) idToFunc[1]).Func));
	}
	
	public class DeSerializeableElement<T>
	{
		public Func<T> Func { get; set; }
		public DeSerializeableElement(Func<T> func)
		{
			Func = func;
		}
	}
	
