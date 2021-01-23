    public string SomeMethod()
    {
    	using (var myRepository = new NonScalableUserRepostory(someConfigInstance))
    	{
    		return myRepository.GetMyString();
    	}
    }
