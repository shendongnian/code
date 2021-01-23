	protected override bool ModifyExistingEntity(Product entity, ProductModel item)
	{
	    bool isModified = false;
		isModified |= (entity.Title!= item.Title) ? (entity.Title = item.Title) == item.Title : false;
		isModified |= (entity.ServerId != item.Id) ? (entity.ServerId = item.Id) == item.Id : false;
	    return isModified;
	}
