	void Main()
	{
		var graphClient = new GraphClient(new Uri("http://localhost.:7474/db/data/"));
		graphClient.Connect();
	
		var supermyId = 4000;
		Person superPerson1 = new Person { name = "SUPER Name5 99900", born = 1903, myId = supermyId };
	
		graphClient.Cypher
				.Create("(person:Person {newUser})")
				.WithParam("newUser", superPerson1)
				.ExecuteWithoutResults();
	
		var regularPersons = new List<Person>();
		for (int i = 0; i < 5000; i++)
		{
			regularPersons.Add(new Person { name = $"Person_{i}", born = 1900+(i%100), myId = i + 4000 });
		}
		
		var now = DateTime.Now;
		graphClient.Cypher
			.Match("(su:Person)")
			.Where((Person su) => su.myId == supermyId)
			.Unwind(regularPersons, "rp")
			.Create("(p:Person {born: rp.born, myId: rp.myId, name:rp.name})-[:SUPER5]->(su)")
			
			.ExecuteWithoutResults();
	
		Console.WriteLine($"Took {(DateTime.Now - now)} to add");
	}
	
	public class Person
	{
		public int myId { get; set;}
		public int born { get;set; }
		public string name { get; set; }
	}
