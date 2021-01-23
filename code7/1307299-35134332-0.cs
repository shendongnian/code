    private TEntity MyMethodGeneric<TEntity>(){
        return _unitofwork.BaseRepositoryFor<TEntity>.createEntity(entity);
    }
    private object MyMethod(Type type){
        var method = GetType().GetMethod("MyMethodGeneric", BindingFlags.Instance|BindingFlags.NonPublic);
        return method.MakeGenericMethod(type).Invoke(this, new object[]{/* if you need to pass parameters}*/);
    }
