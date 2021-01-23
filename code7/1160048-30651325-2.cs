    /// <summary>
    /// Separates the List of string data into groups of data
    /// </summary>
    /// <param name="data">Array of string data</param>
    /// <param name="groupNames">Array of group names</param>
    /// <returns>Dictionary of List of string data broken into groups</returns>
    private Dictionary<string, List<string>> SeparateGroups(string[] data, params string[] groupNames)
    {
        return groupNames.ToDictionary(
                groupName => groupName, 
                groupName => data.Where(ag => ag.StartsWith(groupName) && ag.EndsWith(groupName))
                    .ToList()
        );
    }
