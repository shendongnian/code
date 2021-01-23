    protected override bool ModifyExistingEntity(Product entity, ProductModel item)
    {
        if (!entity.IsEqualTo(item))
        {
            item.CopyDataTo(entity);
            return true;
        }
        return false;
    }
