    public static void Main(string[] args)
    {
    	Type t = typeof(string);
    	Type fooType = typeof(Foo<>);
    	Type genericFooType = fooType.MakeGenericType(t);
    	object o = Activator.CreateInstance(genericFooType,null);
    	MethodInfo method = genericFooType.GetMethod("Bar");
    	method.Invoke(o, null);
    }
    
    public class Foo<T> where T:class
    {
    	public void Bar()
    	{
    		Console.WriteLine ("Calling Bar");
    	}
    }
