    protected override bool ModifyExistingEntity(Product entity, ProductModel item)
    {
        bool isModified = this.IsEntityModified(entity, item);
        this.UpdateEntity(entity, item);
    
        return isModified;
    }
    private bool IsEntityModified(Product entity, ProductModel item)
    {
        return entity.Title != item.Title || entity.ServerId != item.ServerId;
    }
    
    private void UpdateEntity(Product entity, ProductModel item)
    {
        entity.Title = item.Title;
        entity.ServerId = item.Id;
    }
