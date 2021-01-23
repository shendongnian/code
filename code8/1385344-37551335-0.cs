    public static async Task DeleteFilesAsync(StorageFolder folder, Regex mask, LoggingChannel logger)
    {
        var results = (from file in await folder.GetFilesAsync() where mask.IsMatch(file.Name) select file).Select(f => f.DeleteAsync());
        try
        {    
            await Task.WhenAll(results);
        }
        catch(AggregateException ex)
        {
            foreach(var inner in ex.InnerExceptions)
            {
                logger.LogMessage(inner.ToString(), LoggingLevel.Warning);
            }
        }
    }
