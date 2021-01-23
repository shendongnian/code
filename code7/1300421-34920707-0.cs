    private static IEnumerable<object> Flat(IEnumerable<object> items)
    {
        foreach (var item in items)
        {
            var array = item as Array;
            if (array != null)
            {
                foreach (var arrayItem in array)
                    yield return arrayItem;
            }
            else
                yield return item;
        }
    }
