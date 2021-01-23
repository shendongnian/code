    void PreFillKeys(params T[] keys) // use an IEnumerable<T> if handier
    {
        foreach (T key in keys)
        {
            // EITHER THIS:
            if (!_KeyToPoints.ContainsKey(key))
                _KeyToPoints[key] = 0;
            /* OR THIS (faster if you know none of keys was added before)
            try
            {
                _KeyToPoints[key] = 0;
            }
            catch (ArgumentException)
            {
                // ignore >> you shouldn't have called 
            }
            */
        }
    }
