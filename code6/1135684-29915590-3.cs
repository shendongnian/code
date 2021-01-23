    protected override bool ModifyExistingEntity(Product entity, ProductModel item)
    {
        var modifier = new Modifier(entity);
        modifier.Update(e => entity.Title, item.Title);
        modifier.Update(e => entity.ServerId, item.Id);
        return modifier.IsModified;
    }
