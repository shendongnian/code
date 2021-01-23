    var e = myEnumerable.GetEnumerator();
    try
    {
        while (e.MoveNext())
        {
            var f = e.Current;
            // code
        }
    }
    finally
    {
        IDisposable d = e as IDisposable;
        if (d != null)
        {
            d.Dispose();
        }
    }
