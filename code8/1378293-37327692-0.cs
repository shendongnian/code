    IEnumerable<INamedTypeSymbol> GetAllTypes(Compilation compilation) =>
        GetAllTypes(compilation.GlobalNamespace);
    IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol @namespace)
    {
        foreach (var type in @namespace.GetTypeMembers())
            foreach (var nestedType in GetNestedTypes(type))
                yield return nestedType;
        foreach (var nestedNamespace in @namespace.GetNamespaceMembers())
            foreach (var type in GetAllTypes(nestedNamespace))
                yield return type;
    }
    IEnumerable<INamedTypeSymbol> GetNestedTypes(INamedTypeSymbol type)
    {
        yield return type;
        foreach (var nestedType in type.GetTypeMembers()
            .SelectMany(nestedType => GetNestedTypes(nestedType)))
            yield return nestedType;
    }
