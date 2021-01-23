    /// <summary>
    /// Parse MetaInfo field value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static Dictionary<string, string> ParseMetaInfo(string value)
    {
        return value.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(x => x[0], x => x[1]);
    }
