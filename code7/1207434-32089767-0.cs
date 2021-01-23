    /// <summary>
    /// Get a subtab of a another by specifing the columns index
    /// </summary>
    /// <param name="tab">a list of lines of your tab</param>
    /// <param name="columns">the index of columns you want to keep (the order specified will match the result order of columns)</param>
    /// <returns>a list of selected columns</returns>
    public List<string[]> SubTab(List<string[]> tab, params int[] columns)
    {
        // add error handling here like verifying that specified columns exist in tab
        
        var result = new List<string[]>();
        foreach (var line in tab)
        {
            var newLine = new string[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                newLine[i] = line[columns[i]];
            }
            result.Add(newLine);
        }
        return result;
    }
