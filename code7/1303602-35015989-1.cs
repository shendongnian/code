    void Main()
    {
    	var bike = Factory.GetInstance<CheapBike>(() => new Information()
    	{
    		Name = "BMX",
            Description = "..."
    	});
    }
    
    public static class Factory 
    {
    	public static T GetInstance<T>(Func<Information> func) where T : EntityBase
    	{
    		return (T)Activator.CreateInstance(typeof(T), func());
    	}
    }
