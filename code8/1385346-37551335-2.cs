    public static async Task DeleteFilesAsync(StorageFolder folder, Regex mask, LoggingChannel logger)
    {
        var results = (from file in await folder.GetFilesAsync() where mask.IsMatch(file.Name) select file).Select(f => f.DeleteAsync());
        try
        {    
            await Task.WhenAll(results);
        }
        catch(Exception ex)
        {
            foreach (var failed in results.Where(r => r.Exception != null)) logger.LogMessage(failed.Exception.ToString(), LoggingLevel.Warning);
        }
    }
