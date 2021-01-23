    public async Task WriteToFile(
            string path,
            string str,
            int count)
    {
        var fullPath = string.Format("{0}\\{1}_element.txt", path, count);
        using (var sw = File.CreateText(fullPath))
        {
            await sw.WriteLineAsync(str);
        }
        NLog.Trace("Saved in TaskID: {0} to \"{1}\"", 
           Task.CurrentId,
           fullPath);
    }
