    public static T GetMostRepresentedElementStruct<T, U>(this IEnumerable<U> _Collection, Func<U, T> _GetElem)
    {
        var t = _Collection.GroupBy(e => _GetElem(e))
                           .Select(f => new
                           {
                               Count = f.Count(),
                               Elem = f.Key
                           })
                           .OrderByDescending(g => g.Count)
                           .FirstOrDefault();
        if (t == null)
        {
            return default(T);
        }
        else
        {
            return t.Elem;
        }
    }
