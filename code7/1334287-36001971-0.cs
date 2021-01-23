    static void Main(string[] args)
    {
    	var myTeacher = new Teacher { id = "1", firstName = "Steve", lastName = "TheTeacher", gradeNumber = 8 };
    	var myFiregighter = new Firefighter { id = "2", firstName = "Frank", lastName = "TheFirefighter", helmetSize = 12 };
    
    	SingleNodeConnectionPool esPool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	ConnectionSettings esSettings = new ConnectionSettings(esPool);
    	esSettings.DefaultIndex("people");
    	Nest.ElasticClient esClient = new ElasticClient(esSettings);
    
    	if (esClient.IndexExists("people").Exists)
    	{
    		esClient.DeleteIndex("people");
    	}
    	
    	esClient.Index<Teacher>(myTeacher, i => i.Refresh());
    	esClient.Index<Firefighter>(myFiregighter, i => i.Refresh());
    
        // perform the search using the base type i.e. Person
    	ISearchResponse<Person> response = esClient.Search<Person>(s => s
            // Use .Type to specify the derived types that we expect to return
    		.Type(Types.Type(typeof(Teacher), typeof(Firefighter)))
    		.MatchAll()
    	);
    
    	foreach (Person person in response.Documents)
    		Console.WriteLine(person);
    }
    
    public class Person
    {
    	public string id { get; set; }
    	public string firstName { get; set; }
    	public string lastName { get; set; }
    	public override string ToString() { return String.Format("{0}, {1}", lastName, firstName); }
    }
    public class Firefighter : Person
    {
    	public int helmetSize { get; set; }
    }
    public class Teacher : Person
    {
    	public int gradeNumber { get; set; }
    }
