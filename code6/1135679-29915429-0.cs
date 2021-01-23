    protected override bool ModifyExistingEntity(Product entity, ProductModel item)
    {
    	entity.SetTitle(item.Title);
    	entity.SetServerId(item.Id);
    	return entity.WasModified();
    }
