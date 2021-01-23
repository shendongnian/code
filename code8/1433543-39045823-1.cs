    public IObservable<IObservable<Entity>> GetObservable()
    {
    	var rows = new List<EntityTableRow>
    	{
    		new EntityTableRow { Id = 1, StringVal = "One"},
    		new EntityTableRow { Id = 2, StringVal = "Two"},
    	};
    	return rows.ToObservable().Select(i => Observable.Return(BuildEntity(i)));
    }
