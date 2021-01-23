    protected bool ModifyExistingEntity(Person entity, ProductModel item)
    {
        bool isModified = Modify(() => entity.Title = item.Title, () => entity.Title != item.Title);
        isModified |= Modify(() => entity.ServerId = item.Id, () => entity.ServerId != item.Id);
        return isModified;
    }
    private bool Modify(Action setter, Func<bool> comparator)
    {
        if (comparator())
        {
            setter();
            return true;
        }
        return false;
    }
