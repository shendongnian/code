    void AddPoints(T key, int points)
    {
        try
        {
            _KeyToPoints[key] = _KeyToPoints[key] + points;
        }
        catch (ArgumentException)
        {
            _KeyToPoints[key] = points;
        }
    }
