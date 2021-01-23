    public class C
    {
	public static void Show(object value)
	{
		"object".Dump();
	}
	
	public static void Show(int value)
	{
		"int".Dump();
	}
	
	public static void Show(string value)
	{
		"string".Dump();
	}
    }
    public class MyClass<T>
    {
       public void Append(T value)
       {
	C.Show(value);
       }
    }
    public void Main()
    {
	var c1 = new MyClass<int>();
	var c2 = new MyClass<string>();
	var c3 = new MyClass<object>();
	
	c1.Append(1);
	c2.Append("1");
	c3.Append(2);
    }
