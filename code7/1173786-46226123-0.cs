    public static void Main()
	{	
		string json = @"
		{
			'Name': 'foo',
			'Id': 123
		}{
			'Name': 'bar',
			'Id': 456
		}
		
		//more new line
		{
			'Name': 'jar',
			'Id': 789
		}
		";
	
	     var persons = DeserializeObjects<Person>(json).ToList();
	     Console.WriteLine(persons.Count());
	     foreach ( var person in persons)
	    {
	      Console.WriteLine("id: {0}, Name: {1}",person.Id, person.Name);
	    }
}
		static IEnumerable<T> DeserializeObjects<T>(string input)
		{
			JsonSerializer serializer = new JsonSerializer();
			using (var strreader = new StringReader(input)) 
			using (var jsonreader = new JsonTextReader(strreader))
			{
                    //you should use this line
					jsonreader.SupportMultipleContent = true;
					while (jsonreader.Read()) 
					{						
						yield return  serializer.Deserialize<T>(jsonreader);
					}
				
			}
		}
		 
		class Person
		{
		  public int Id {get;set;}
		  public string  Name {get;set;}
		}
