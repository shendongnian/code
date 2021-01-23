    /// <summary>
    /// Gets the closest matching <see cref="JsonProperty"/> object.
    /// First attempts to get an exact case match of propertyName and then
    /// a case insensitive match.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <returns>A matching property if found.</returns>
    public JsonProperty GetClosestMatchProperty(string propertyName)
    {
        JsonProperty property = GetProperty(propertyName, StringComparison.Ordinal);
        if (property == null)
        {
            property = GetProperty(propertyName, StringComparison.OrdinalIgnoreCase);
        }
        return property;
    }
