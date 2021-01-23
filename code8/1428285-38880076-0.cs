    public static IDictionary<DateTime, int> ShiftContent(
            this IDictionary<DateTime, int> inputDictionary, int size)
    {
        var minDate = inputDictionary.Keys.Min();
        var result = inputDictionary.ToDictionary(a => a.Key.AddMonths(size), a => a.Value);
        for (int i = 0; i < size; i++)
            result[minDate.AddMonths(i)] = 0;
        return result;
    }
