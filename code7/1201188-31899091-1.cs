    class Car {
    	public Car()
    	{
    		UniqueIdentifier = new Guid().ToString();
    	}
    
    	public string UniqueIdentifier { get; private set; }
    }
