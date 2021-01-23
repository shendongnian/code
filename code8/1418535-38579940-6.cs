    var itemarray = new Base[] { new Derived<int>(), new Derived<string>() };
    foreach (var baseObject in itemarray)
    {
        var derivedType = baseObject.GetType();
        var visitMethod = typeof(Visitor)
            .GetMethod("Visit")
            .MakeGenericMethod(derivedType.GetGenericArguments());
        visitMethod.Invoke(null, new[] { baseObject });
    }
