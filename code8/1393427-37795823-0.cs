    var test = Orientation.North;
    var flagCount = GetFlagCount(test);
    public int GetFlagCount(Enum testValue)
    {
        return Enum.GetValues(testValue.GetType()).Count(x => testValue.HasFlag(x));
    }
