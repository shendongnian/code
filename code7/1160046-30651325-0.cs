    /// <summary>
    /// Separates the List of string data into groups of data
    /// </summary>
    /// <param name="data">Array of string data</param>
    /// <param name="groupNames">Array of group names</param>
    /// <returns>Dictionary of List of string data broken into groups</returns>
    private Dictionary<string, List<string>> SeparateGroups(string[] data, params string[] groupNames)
    {
        Dictionary<string, List<string>> separateGroups = new Dictionary<string, List<string>>();
        foreach (string groupName in groupNames)
        {
            separateGroups.Add(groupName, data.Where(ag => ag.StartsWith(groupName) && ag.EndsWith(groupName)).ToList());
        }
        return separateGroups;
    }
