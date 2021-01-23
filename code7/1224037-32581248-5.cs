    public static IEnumerable<IMyInterface> GetData(string id)
    {
        if (id == "-string1" || id == "-all")
            yield return new ClassX();
        if (id == "-string2" || id == "-all")
            yield return new ClassY();
        if (id == "-string3" || id == "-all")
            yield return new ClassX();
    }
