    class MyAbstract<T>
    {
    	public T MySomething;
    }
    
    class ConcreteA : MyAbstract<int>
    {
    	
    }
    
    class ConcreteB : MyAbstract<string>
    {
    	
    }
    
    class Implementation<T> where T : MyAbstract<T>
    {
    	private T myConcrete;
        void DoSomething()
    	{
    		Console.Write(myConcrete.MySomething.ToString());
    	}
    
    }
