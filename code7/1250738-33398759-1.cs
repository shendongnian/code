    public static TModel ObjectToModel<TSource, TModel>(this TSource source, string[] propsToExclude = null)
        where TModel : new()
    {
        var dest = new TModel();
        source.CopyPropertiesToObject(dest, propsToExclude);
        return dest;
    }
