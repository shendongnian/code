    class Car : Vehicle
    {
    	public string brand { get; set; }
    	public string type { get; set; }
    	public int maxSpeed { get; set; }
    	public double price { get; set; }
    	public int carID { get; private set; }
    	
    	public static int globalCarID;
    
    
    
    	public Car(string _brand, string _type, int _maxspeed, double _price)
    	{
    		this.brand = _brand;
    		this.type = _type;
    		this.maxSpeed = _maxspeed;
    		this.price = _price;
    		this.carID = Interlocked.Increment(ref globalCarID);
    	}
    }
