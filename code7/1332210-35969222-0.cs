    public class Car
    {
    	public string Make { get; set;}
    	public string Model { get; set; }
    	public int Year { get; set; }
    	public string Color { get; set; }
    }
    
    void Main()
    {
    	List<Car> cars;
    	using (var fileReader = File.OpenText("Cars.txt"))
    	{
    		using (var csv = new CsvHelper.CsvReader(fileReader))
    		{
    			cars = csv.GetRecords<Car>().ToList();
    		}
    	}
    	// cars now contains a list of Car-objects read from CSV.
        // Header fields (first line of CSV) has been automatically matched to property names.	
		// Set up the dictionary. Note that the key must be unique.
		var carDict = cars.ToDictionary(c => c.Make);        
    }
