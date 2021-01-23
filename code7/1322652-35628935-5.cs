    void Main()
    {
      // By Hard coding. 
      /*
    	TransportationCostCalculator.AddTravelModifier("bicycle", 1);
    	TransportationCostCalculator.AddTravelModifier("bus", 2);
    	TransportationCostCalculator.AddTravelModifier("car", 3);
      */
    	//By File 
    	//assuming file is: name,value
    	System.IO.File.ReadAllLines("C:\\temp\\modifiers.txt")
    	.ToList().ForEach(line =>
    		{
    		   var parts = line.Split(',');
    	   	TransportationCostCalculator.AddTravelModifier
                (parts[0], Double.Parse(parts[1]));
    		}
    	);
    	
    }
    
    public class TransportationCostCalculator {
        static Dictionary<string,double> _travelModifier = 
             new Dictionary<string,double> ();
    
    	public static void AddTravelModifier(string name, double modifier)
    	{
    		if (_travelModifier.ContainsKey(name))
    		{
    			throw new Exception($"{name} already exists in dictionary.");
    		}
    		
    		_travelModifier.Add(name, modifier);
    	}
    	
    	public double DistanceToDestination { get; set; }
    
        TransportationCostCalculator()
        {
            _travelModifier = new Dictionary<string,double> ();
        }
    
    
        public decimal CostOfTravel(string transportationMethod) =>
           (decimal)( _travelModifier[transportationMethod] * DistanceToDestination);
    }
