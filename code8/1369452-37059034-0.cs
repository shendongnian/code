    List<TKey> keys;
    if (dict2.TryGetValue(obstacle, out keys))
    {
        foreach (TKey key in keys)
        {
            obstacleMap.Remove(key);
        }
        dict2.Remove(obstacle);
    }
