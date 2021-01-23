    class MyAbstract<T>
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
    	private MyAbstract<T> myConcrete;
    
    	public Implementation(T a)
    	{
    		myConcrete = new ConcreteA<T>(4);
    	}
    
    	void DoSomething()
    	{
    		Console.Write(myConcrete.MySomething.ToString());
    	}
    }
