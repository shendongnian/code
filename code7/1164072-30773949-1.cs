    void FunctionX(SocialNetworks provider, object obj)
    {
    	switch(provider)
    	{
    			   case SocialNetworks.Linkedin:
    					{
    						FunctionY<Linkedin>(obj as Linkedin);
    						break;
    					}
    				case SocialNetworks.Facebook:
    					{
    						FunctionY<Facebook>(obj as Facebook);
    						break;
    					}
    				case SocialNetworks.Twitter:
    					{
    						FunctionY<Twitter>(obj as Twitter);
    						break;
    					}
    	}
    }
    
    void FunctionY<T>(SocialNetwork obj)
    {
    	List<T> profiles = await MobileService.GetTable<T>().Where(p => p.uuid == (obj).uuid).ToListAsync();
    	if (profiles.Count == 0)
    	{
    		await MobileService.GetTable<T>().InsertAsync(obj);
    	}
    }
