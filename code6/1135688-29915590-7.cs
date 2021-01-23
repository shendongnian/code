    protected override bool ModifyExistingEntity(Product entity, ProductModel item)
    {
        var modifier = new Modifier<Product>(entity);
        modifier.Update(e => e.Title, item.Title);
        modifier.Update(e => e.ServerId, item.Id);
        return modifier.IsModified;
    }
