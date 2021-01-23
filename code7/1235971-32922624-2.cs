    public class Car
    {
    	public Car()
    	{
    		Acessory = new List<Accessories>();
    	}
    
    	public string Model { get; set; }
    	public string CarType { get; set; }
    	public List<Accessories> Accessory  { get; set; }
    	public string Price { get; set; }
    
    	public static List<Car> GetCars()
    	{
    		// Car 1
    		Car Car1 = new Car();
    		Car1.Model = "Range Rover Evoque";
    		Car1.CarType = "SUV";
    		Car1.Price = "70 Lac";
    
    		Car.Accessories car1Interior = new Car.Accessories
    		{
    			LetherSeats = "Front and Back",
    			Music = "CD Player",
    			GPS = "Touch Screen"
    		};
    
    		Car.Accessories car1Ext = new Car.Accessories
    		{
    			LetherSeats = "Front Only",
    			Music = "No",
    			GPS = "No"
    		};
    
    		Car1.Accessory.Add(car1Interior);
    		Car1.Accessory.Add(car1Ext);
    
    		// Car 2
    		Car Car2 = new Car();
    		Car2.Model = "Lamborghini Sesto Elemento";
    		Car2.CarType = "Racing";
    
    		Car.Accessories car2Interior = new Car.Accessories
    		{
    			LetherSeats = "Front and Back",
    			Music = "None",
    			GPS = "Touch Screen"
    		};
    		Car.Accessories car2Ext = new Car.Accessories
    		{
    			FogLights = "None",
    			Spolier = "Yes",
    			NeonLight = "Yes"
    		};
    
    		Car2.Accessory.Add(car2Interior);
    		Car2.Accessory.Add(car2Ext);
    
    		Car2.Price = "2 Crore";
    
    		List<Car> cars = new List<Car>();
    		cars.Add(Car1);
    		cars.Add(Car2);
    
    		return cars;
    	}
    
    
    	public class Accessories
    	{
    		private string _LeatherSeats;
    		private string _GPS;
    		private string _Music;
    		private string _FogLights;
    		private string _Spoiler;
    		private string _NeonLight;
    
    		public string LetherSeats { get { return _LeatherSeats; } set { _LeatherSeats = value; } }
    		public string GPS { get { return _GPS; } set { _GPS = value; } }
    		public string Music { get { return _Music; } set { _Music = value; } }
    		public string FogLights { get { return _FogLights; } set { _FogLights = value; } }
    		public string Spolier { get { return _Spoiler; } set { _Spoiler = value; } }
    		public string NeonLight { get { return _NeonLight; } set { _NeonLight = value; } }
    	}
    }
