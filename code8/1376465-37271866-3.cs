    public class Movement
    {
        public string Name { get; set; }
    	public double Values { get; private set; }
        public double Time { get; private set; }
    	
    	public Movement(string name, double values, double time)
    	{
    		Name = name;
    		Values = values;
    		Time = time;
    	}
    }
    
    public class Step
    {
        public string Name { get; set; }
    	public IList<Movement> Movements { get; set; }
    }
    
    public class Vehicle
    {
        public string Id { get; set; } // Should be changed to string
        public string Description { get; set; }
    	public IList<Step> Steps { get; set; }
    }
