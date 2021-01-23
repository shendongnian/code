    if (o.GetType().IsGenericType && o is System.Collections.IEnumerable)
    {
        var itemType = o.GetType().GetGenericArguments()[0];
        //Console.WriteLine(itemType);
    }
