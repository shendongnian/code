    void Main()
    {
    	SearchAnimals("white").Dump();
    }
    
    public List<Animal> SearchAnimals(string searchVar)
    {
    	var animals = new List<Animal>()
    	{
    		new Animal { Animal_ID = 1, Color = "black", Breed = "other" },
    		new Animal { Animal_ID = 2, Color = "white", Breed = "other" },
    		new Animal { Animal_ID = 3, Color = "blue", Breed = "terrier" },
    		new Animal { Animal_ID = 4, Color = "green", Breed = "other" }
    	};
    
    	var result = !String.IsNullOrEmpty(searchVar) ? 
        	animals.Where(x => x.Color == "white" || 
        	x.Breed == "terrier") : new List<Animal>();
    		
    	return result.ToList();
    }
    
    public class Animal
    {
    	public int Animal_ID { get; set; }
    	public string Color { get; set; }
    	public string Breed { get; set; }
    }
