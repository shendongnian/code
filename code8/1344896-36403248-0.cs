    private void doStuff(){
    	var listOfRows = Session.CreateSQLQuery(Sql.GetPerson)
    		.List();
    
    	var listOfPersonRows = new List<Person>();
    
    	if (listOfRows.Count != 0)
    	{
    		for (var i = 0; i < listOfRows.Count; i++)
    		{
    			var item = (object[])listOfRows[i];
    			listOfPersonRows.Add(ConvertToRow(item));
    		}
    	}
    }
    
    private Person ConvertToRow(object[] item)
    {
    	var personRow = new Person();
    
    	personRow.Name = (string)item[0];
    	personRow.Dog.Age = (int)item[1];
    	
    
    	return personRow;
    }
