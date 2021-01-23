    [Fact]
    public void Test_WithTypesAndReflection_Succeeds()
    {
        var typeMapper = new Dictionary<string, Type>()
        {
            { "Apple", typeof(Apple) },
            { "Orange", typeof(Orange) }
        };
        var method = (
            from m in this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            where m.Name == "GetFruit"
            where m.GetParameters().Count() == 0
            select m).Single();
        var result = (IEnumerable<Fruit>)method
            .MakeGenericMethod(typeMapper["Apple"])
            .Invoke(this, null);
    }
    private IEnumerable<Fruit> GetFruit<T>() where T : Fruit
    {
        return Enumerable.Empty<T>().Cast<Fruit>();
    }
