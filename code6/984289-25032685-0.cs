    static void Main()
    {
        Foo<Employee>();
    }
    static void Foo<TEntity>() {
        var properties = typeof(TEntity).GetProperties().Where(m =>
            m.PropertyType.IsGenericType &&
            m.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
        ).ToArray();
        // ^^^ contains Addresses and Performances
    }
