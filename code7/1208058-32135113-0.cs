    public static K FirstWindowWhere<K, V>(
        this Series<K, V> series,
        Func<List<KeyValuePair<K, V>>, bool> condition,
        int windowSize)
    {
        var theData = series.GetObservations().ToList();
         
        for (int i = 0; i < theData.Count() - windowSize; i++)
        {
            var window = theData.GetRange(i, windowSize);
            if (condition(window))
            {
                return theData[i].Key;
            }
        }
        return default(K);
    }
