    public IEnumerable<Person> GetPersons()
    {
        var result = new List<Person>();
    	
    	using (var connection = new SqlConnection("connection string"))
    	{
           // I know it is a person command, because it is in a method for it.
           // Keep it simple!
    	   using (var command = new SqlCommand("select id, name from persons", connection))
    	   {
    		  using (var reader = command.ExecuteReader())
    		  { 
    			  while (reader.Read())
    			  {
    			      result.Add(new Person() {
    				     Id = (int) reader["id"];
    					 Name = reader["name"] as string;					 
    				  });
    			  }
    		  } // reader is disposed here
    	   } // command is disposed here
    	} // connection is disposed here
    	
    	return result;
    }
