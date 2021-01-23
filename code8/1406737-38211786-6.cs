    public static Repository<T> GetRepository()
    {
        if (typeof(T) == typeof(Customer))
            return (Repository<T>)(object)new Repository<Customer>();
        if (typeof(T) == typeof(Product))
            return (Repository<T>)(object)new Repository<Product>();
        throw new Exception("Entity of type " + typeof(IEntity).Name + " is not supported.");
    }
