    public int InsertOrReplaceAll(IEnumerable objects, Type objType)
    {
        var c = 0;
        RunInTransaction(() =>
        {
            foreach (var r in objects)
            {
                c += InsertOrReplace(r, objType);
            }
        });
        return c;
    }
