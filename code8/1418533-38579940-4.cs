    var itemarray = new Base[] { new Derived<int>(), new Derived<string>() };
    foreach (var baseObject in itemarray)
    {
        var derivedType = baseObject.GetType();
        var visitMethod = typeof(Visitor)
            .GetMethod("Visit")
            .MakeGenericMethod(new[] { derivedType.GetGenericArguments()[0] });
        visitMethod.Invoke(null, new[] { baseObject });
    }
