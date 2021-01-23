    void Main()
    {
    	var samplePerson = Builder<Person>.CreateNew().Build();
    	
    	var json = JsonConvert.SerializeObject(samplePerson);
    	
    	//outputs {"Name":"Name1","Age":1} to the screen
    	json.Dump();
    }
    
    public class Person
    {
    	public string Name { get; set; }
    	public int Age { get; set; }
    }
