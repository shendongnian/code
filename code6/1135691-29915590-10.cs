    protected override bool ModifyExistingEntity(Product entity, ProductModel item)
    {
        return new Modifier<Product>(entity)
                   .SetIfNeeded(e => e.Title, item.Title);
                   .SetIfNeeded(e => e.ServerId, item.Id);
                   .EntityWasModified;
    }
