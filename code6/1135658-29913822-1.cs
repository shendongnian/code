    protected bool ModifyExistingEntity(Person entity, ProductModel item)
    {
        bool isModified = CompareAndModify(() => entity.Title = item.Title, () => entity.Title != item.Title);
        isModified |= CompareAndModify(() => entity.ServerId = item.Id, () => entity.ServerId != item.Id);
        return isModified;
    }
    private bool CompareAndModify(Action setter, Func<bool> comparator)
    {
        if (comparator())
        {
            setter();
            return true;
        }
        return false;
    }
