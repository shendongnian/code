    protected override bool ModifyExistingEntity(Product entity, ProductModel item)
    {
        return new Modifier<Product>(entity)
                   .UpdateIfNeeded(e => e.Title, item.Title);
                   .UpdateIfNeeded(e => e.ServerId, item.Id);
                   .EntityWasModified;
    }
