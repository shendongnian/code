    public void Save()
    {
        //Get the generic type of your model
		var type = typeof(Repository<>).MakeGenericType(this.GetType());
        //need dynamic here so we can call arbitrary methods on it later
		dynamic repository = Activator.CreateInstance(type);
        //Need to cast to dynamic or you will get an error
		repository.Save((dynamic)this);
        
    }
