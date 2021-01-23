    private object StripTuple(object tuple, int[] mask)
    {
        int[] indexes = mask.Select((v, i) => new { val = v, index = i }).Where(o => o.val == 1).Select(i => i.index).ToArray();
        object[] items = new object[indexes.Length];
        Type[] tupleTypes = new Type[indexes.Length];
        var originalTupleType = tuple.GetType();
        var genericArgs = originalTupleType.GetGenericArguments();
        for (var i = 0; i < indexes.Length; i++)
        {
            items[i] = originalTupleType.GetProperty("Item" + (indexes[i] + 1)).GetValue(tuple);
            tupleTypes[i] = genericArgs[indexes[i]];
        }
        Type tupleType = Type.GetType("System.Tuple`" + indexes.Length);
        Type newTupleType = tupleType.MakeGenericType(tupleTypes);
        return Activator.CreateInstance(newTupleType, items);
    }
