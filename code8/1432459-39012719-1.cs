	// Initialize data
	List<DataModel> dataModels = new List<DataModel>
	{
		new DataModel { Data = new byte[]{0xFF,0xFF} },
		new DataModel { Data = new byte[]{0x01,0x01} }
	};
	// Add it to database
	using(MyContext context = new MyContext())
	{
		context.DataModels.Add(dataModels);
		context.SaveChanges();
	}
