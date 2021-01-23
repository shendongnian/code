    public class Root 
    {
    	public CarHolder Cars {get;set;}
    }
    public class CarHolder
    {
    	public IList<Car> Car { get; set; }
    }
    public class Car
    {
        public Car() { }
    
        public string car_name { get; set; }
        public string Country { get; set; }
    	
    	public EngineHolder Engines { get; set; }
    }
    public class EngineHolder 
    {
    	[JsonConverter(typeof(SingleOrArrayConverter<Engine>))]
        public List<Engine> Engine { get; set; }
    }
    public class Engine
    {
    	public string Name { get; set; }
    }
