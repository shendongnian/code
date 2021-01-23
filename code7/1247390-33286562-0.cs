    void Main()
    {
	  var a = new InputVO<string> { value = "test" };
  	  var b = new InputVO<int> { value = 5 };
      Inputs.Add(typeof(string), a);
	  Inputs.Add(typeof(int), b);
	
	  var x = GetInput(typeof(string));
	  var y = x as InputVO<string>;
	  Console.WriteLine(y.value);
    }
    public class InputVO<T>
    {
      public bool isEnabled;
	  public T value;
    }
    public Dictionary<Type, object> Inputs = new Dictionary<Type, object>();
    public object GetInput(Type type)
    {
	  if (type == typeof(string))
		return Inputs[typeof(string)] as InputVO<string>;
	  if (type == typeof(int))
		return Inputs[typeof(int)] as InputVO<int>;
  	  // ...
	  throw new Exception("No type stored");
    }
