  	private StudentDatabaseEntities db = new StudentDatabaseEntities();
  
	public List<StudentDatabaseDbTableModel> AllProducts()
	{
		return db.StudentDatabaseDbTableModel.ToList();
	}	
