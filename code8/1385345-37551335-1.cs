    public static async Task DeleteFilesAsync(StorageFolder folder, Regex mask, LoggingChannel logger)
    {
        var results = (from file in await folder.GetFilesAsync() where mask.IsMatch(file.Name) select file).Select(f => f.DeleteAsync());
        try
        {    
            await Task.WhenAll(results);
        }
        catch(Exception ex)
        {
            logger.LogMessage(ex.ToString(), LoggingLevel.Warning);
        }
    }
or do Task.WaitAll(results) and catch the AggregateException
