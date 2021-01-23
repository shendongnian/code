    protected override bool ModifyExistingEntity(Product entity, ProductModel item)
    {
        bool isEntityModified = entity.Title != item.Title || entity.ServerId != item.ServerId;
        entity.Title = item.Title;
        entity.ServerId = item.Id;
        return isEntityModified;
    }
