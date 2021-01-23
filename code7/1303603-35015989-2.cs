    void Main()
    {
    	var bike = Factory.GetInstance<CheapBike>(() => new Information()
    	{
    		Name = "BMX",
            Description = "..."
    	});
        //or
        var bike = Factory.GetInstance<CheapBike>(GetInfo);
    }
    private Information GetInfo()
    {
         //do some logic to populate the info object to be passed
         //into the constructor during factory initialization
         return yourPopulatedInfoObject;
    }
    
    public static class Factory 
    {
    	public static T GetInstance<T>(Func<Information> func) where T : EntityBase
    	{
    		return (T)Activator.CreateInstance(typeof(T), func());
    	}
    }
