    interface IUserNameFactory
    {
    	string BuildUserName();
    }
    
    class ProductionFactory : IUserNameFactory
    {
    	public BuildUserName() { return User.Identity.Name; }
    }
    
    class MockFactory : IUserNameFactory
    {
    	public BuildUserName() { return "James"; }
    }
    
    IUserNameFactory factory;
    
    if(inProductionMode)
    {
    	factory = new ProductionFactory();
    }
    else
    {
    	factory = new MockFactory();
    }
    
    SettingsViewModel svm = _context.MySettings(factory.BuildUserName());
