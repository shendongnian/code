    void Main()
    {
    	var list = new List<Coordinate>()
    	{
    		new Coordinate(25.25251, 100.21254),
    		new Coordinate(25.25252, 100.21255),
    		new Coordinate(25.25253, 100.21256),
    		new Coordinate(25.80000, 100.90000)
    	};
    	int precision = 4;
    	var res = list.Select(x => new Coordinate(
                                   Math.Round(x.Lon, precision), 
                                   Math.Round(x.Lat, precision))).Distinct().ToList();
    }
    
    public struct Coordinate
    {
    	private double lon;
    	private double lat;
    	
    	public Coordinate(double lon, double lat)
    	{
    		this.lon = lon;
    		this.lat = lat;
    	}
    	
        public double Lat { get { return lat; } }
        public double Lon { get { return lon; } }
    }
