	public SomeModel Get(int id)
	{
		var database = new Database();
		var record = database.SomeModels.Get(id);
		record.FooProperty = DoSomeLogic();
		
		// and so on
		
		return record;
	}
