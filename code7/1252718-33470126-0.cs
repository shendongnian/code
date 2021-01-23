    private object dbContext;
	public LoginViewModel()
	{
		dbContext = new S_ERP_DBEntities();
	}
	public LoginViewModel(object dbEntities)
	{
		dbContext = dbEntities;
	}
