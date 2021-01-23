    public List<Stuff> GetStuff(string type1, string type2, bool? isX, bool? isY, bool? isZ)
    {
        var type = SomeService.GetType();
        var flags = BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.InvokeMethod |
                    BindingFlags.OptionalParamBinding;
        var args = new object[]
        {
            type1 ?? Type.Missing,
            type2 ?? Type.Missing,
            isX ?? Type.Missing,
            isY ?? Type.Missing,
            isZ ?? Type.Missing
        };
        return (List<Stuff>)type.InvokeMember(
            nameof(SomeService.GiveMeTheStuff), flags, null, SomeService, args);
    }
