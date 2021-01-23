    public static void Load(this IQueryable source)
    {
        Check.NotNull(source, "source");
        var enumerator = source.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
            }
        }
        finally
        {
            var asDisposable = enumerator as IDisposable;
            if (asDisposable != null)
            {
                asDisposable.Dispose();
            }
        }
    }
