    /// <summary>
    /// Separates the List of string data into groups of data
    /// </summary>
    /// <param name="data">Array of string data</param>
    /// <param name="groupNames">Array of group names</param>
    /// <returns>Dictionary of List of string data broken into groups</returns>
    private static Dictionary<string, List<string>> SeparateGroups(string[] data, params string[] groupNames)
    {
        return groupNames.ToDictionary(
            groupName => groupName,
            groupName => data.Select(d => {
                Match m = Regex.Match(d, String.Format("^\\*{{11,}}BEGIN PROCESSING {0} PNRS\\*{{11,}}\\s(.*)\\s\\*{{11,}}END PROCESSING {0} PNRS\\*{{11,}}$", groupName));
                return m.Success ? m.Groups[1].Value : String.Empty;
            }).Where(s => !String.IsNullOrEmpty(s)).ToList()
        );
    }
