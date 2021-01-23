    [TestMethod]
    public void DifferentTitleAndId_ExpectModified()
    {
        var entity = new Product
            {
                Id = 0,
                ServerId = 0,
                Title = "entity title"
            };
    
        var model = new ProductModel
            {
                Id = 1,
                Title = "model title"
            };
    
        bool isModified = ModifyExistingEntity(entity, model);
    
        Assert.IsTrue(isModified);
    }
    
    protected bool ModifyExistingEntity(Product entity, ProductModel model)
    {
        return
            IsModified(entity.Title, model.Title, x => entity.Title = x) |
            IsModified(entity.ServerId, model.Id, x => entity.ServerId = x);
    }
    
    protected bool IsModified<T>(T value1, T value2, Action<T> setter)
    {
        return IsModified(() => value1, () => value2, () => setter(value2));
    }
    
    protected bool IsModified<T>(Func<T> valueGetter1, Func<T> valueGetter2, Action setter)
    {
        if (!Equals(valueGetter1(), valueGetter2()))
        {
            setter();
            return true;
        }
    
        return false;
    }
