    private Logbook PassLog(Logbook entity)
    {
    	if (entity == null)
    	{
    		entity = this.NewLogbook();
    	}
    
    	entity.EditedDate = this.dateTimeProvider.Now;
    	entity.EditorID = this.services.CurrentUser.ID;
    
    	return entity;
    }
