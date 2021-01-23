    public static object shrink(this object source, params int[] mask)
    {
        var props = source.GetType().GetProperties();
        var items = mask
                   .Select((val, index) => new { val, index })
                   .Where(x => x.val != 0)
                   .Select((x, index) => new
                   {
                       name = "Item" + index,
                       val = props[x.index].GetValue(source)
                   })
                   .ToList();
        var expando = new ExpandoObject() as IDictionary<string, object>;
        foreach (var item in items)
            expando[item.name] = item.val;
        return expando;
    }
