    class GenericContainerOne<T> { }
    class GenericContainerTwo<T> { }
    class Construct { }
    static void Main(string[] args)
    {
        GenericContainerOne<Construct> returnObject = (GenericContainerOne<Construct>)GetGenericObject(typeof(GenericContainerOne<>), typeof(Construct));
    }
    static object GetGenericObject(Type container, Type construct)
    {
        Type genericType = container.MakeGenericType(construct);
        return Activator.CreateInstance(genericType);
    }
