    /// <summary>
    ///     Deserializes object or an array of objects from a list of files.
    /// </summary>
    public static List<T> Deserialize<T>(List<string> filePathsList)
    {
        return filePathsList
            .Select(System.IO.File.ReadAllText)
            .Select(JsonConvert.DeserializeObject<T>)
            .ToList();
    }
