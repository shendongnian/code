    public bool Create(DbContext context, Operator op, System.Type requestedType, params object[] items)
    {
        T[] itemsArray = (T[])new Object[items.Length];
        itemsArray = items.Select(eachObject => (T)eachObject).ToArray();
        return operators.ContainsKey(op) ? operators[op](itemsArray, context, requestedType) : false;
    }
