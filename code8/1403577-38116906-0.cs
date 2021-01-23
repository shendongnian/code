    private static int getData(Dictionary<DateTime, int> values, DateTime start, DateTime stop)
    {
        // Reduce the scope
        var val = values.Where(x => x.Key >= start && x.Key <= stop);
        // Create a list of ranges
        List<Dictionary<DateTime, int>> listOfMonth = new List<Dictionary<DateTime, int>>
        {
            new Dictionary<DateTime, int>()
        };
        var currentMonth = listOfMonth.Last();
        int previousValue = int.MinValue;
        foreach (KeyValuePair<DateTime, int> keyValuePair in val)
        {
            // Reset the month
            if (keyValuePair.Value < previousValue)
            {
                currentMonth = new Dictionary<DateTime, int>()
                {
                    // Add placeholder
                    {DateTime.Now, 0}
                };
                listOfMonth.Add(currentMonth);
                
            }
            previousValue = keyValuePair.Value;
            currentMonth.Add(keyValuePair.Key, keyValuePair.Value);
        }
        return listOfMonth.Sum(dictionary => dictionary.Values.Max() - dictionary.Values.Min());
    }
