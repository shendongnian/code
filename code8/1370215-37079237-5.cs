    class Program
    {
    	static void Main(string[] args)
    	{
    		var myImplementation = new Implementation<int>(4);
    		var myImplementation2 = new Implementation<string>("Hello World");
    
    		Console.WriteLine(myImplementation.myConcreteField); // outputs 4!
    		Console.WriteLine(myImplementation2.myConcreteField); // outputs Hello World
    	}
    }
    abstract class MyAbstract<T>
    {
    	public T MySomething;
    	public MyAbstract(T something)
    	{
    		MySomething = something;
    	}
    }
    
    class ConcreteA<T> : MyAbstract<T>
    {
    	public ConcreteA(int something) : base((T)Convert.ChangeType(something, typeof(T)))
    	{
    	}
    }
    
    class ConcreteB<T> : MyAbstract<T>
    {
    	public ConcreteB(string something) : base((T)Convert.ChangeType(something, typeof(T)))
    	{
    	}
    }
    
    class Implementation<T>
    {
    	public MyAbstract<T> myConcreteField;
    
    	public Implementation(T a)
    	{
    		myConcreteField = new ConcreteA<T>(4);
    	}
    
    	void DoSomething()
    	{
    		Console.Write(myConcreteField.MySomething.ToString());
    	}
    }
