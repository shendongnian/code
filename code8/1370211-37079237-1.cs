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
        public Implementation(T a)
        {
            myConcrete.MySomething = a;
        }
    
    	void DoSomething()
    	{
    		Console.Write(myConcrete.MySomething.ToString());
    	}
    
    }
