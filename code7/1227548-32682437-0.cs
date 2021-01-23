    private object StripTuple(object tuple, int len)
    {
        object[] items = new object[len];
        var orignalTupleType = tuple.GetType();
        for (var i = 1; i <= len; i++)
        {
            items[i - 1] = orignalTupleType.GetProperty("Item" + i).GetValue(tuple);
        }
        Type tupleType = Type.GetType("System.Tuple`" + len);
        Type newTupleType = tupleType.MakeGenericType(orignalTupleType.GetGenericArguments().Take(len).ToArray());
        return Activator.CreateInstance(newTupleType, items);
    }
