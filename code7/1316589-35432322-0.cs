    public static void Foo<T>(T item)
    {
        Console.WriteLine(typeof(T).Name);
    }
    ...
    fooOfBarMethod.Invoke(null, new object[] { new Bar() });
