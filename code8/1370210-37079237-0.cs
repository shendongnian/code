    class MyAbstract<T>
    {
    	public T MySomething;
    }
    
    class ConcreteA : MyAbstract<int>
    {
    	public ConcreteA(int a)
    	{
    		MySomething = a;
    	}
    }
    
    class ConcreteB : MyAbstract<string>
    {
    	public ConcreteB(string a)
    	{
    		MySomething = a;
    	}
    }
    
    class Implementation<T> where T : MyAbstract<T>
    {
    	private T myConcrete;
    
    	void DoSomething()
    	{
    		Console.Write(myConcrete.MySomething.ToString());
    	}
    
    }
