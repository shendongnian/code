	void Main()
	{
		var a = new InputVO<string> { Value = "test" };
		var b = new InputVO<int> { Value = 5 };
		Inputs.Add(typeof(string), a);
		Inputs.Add(typeof(int), b);
	
		var x = GetInput<string>();
		Console.WriteLine(x.Value);
		var y = GetInput<int>();
		Console.WriteLine(y.Value);
	}
	
	public abstract class InputVOBase
	{
		public bool isEnabled;
	}
	
	public class InputVO<T> : InputVOBase
	{
		public T Value;
	}
	
	public Dictionary<Type, InputVOBase> Inputs = new Dictionary<Type, InputVOBase>();
	
	public InputVO<T> GetInput<T>()
	{
		return Inputs[typeof(T)] as InputVO<T>;
	}
