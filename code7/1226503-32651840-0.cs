    void Main()
    {
    	var hobbies = new List<Hobby>()
    	{
    		new Hobby { ID = 1, Name = "Test 1" },
    		new Hobby { ID = 2, Name = "Test 2" },
    		new Hobby { ID = 3, Name = "Test 3" },
    		new Hobby { ID = 4, Name = "Test 4" }
    	};
    	
    	var ids = new[] { 2, 3 };
    	
    	var rest = hobbies.Where(x => !ids.Contains(x.ID)).ToList();
    	rest.Dump();
    }
    
    public class Hobby
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    }
    ID  Name
    1   Test 1 
    4   Test 4 
