    class ClosureCraziness
    {
        public string SaveFolder { get; set; }
    
        public void Save(Dictionary<string, string> idToWebLocation)
        {
            var tasks = new List<Task>();
            foreach (var kvp in idToWebLocation)
            {
                tasks.Add(Download(kvp.Key, kvp.Value));
            }
    
            Task.WaitAll(tasks.ToArray());
        }
    
        async Task Download(string id, string location)
        {
            var filename = $"{id}.html";
            string source = string.Empty;
            try
            {
                source = await GetSource(location);
            }
            catch (Exception e)
            {
                filename = "e-" + filename;
                var ex = e;
                while (ex != null)
                {
                    source += ex.Message;
                    source += Environment.NewLine;
                    source += Environment.NewLine;
                    source += ex.StackTrace;
                    ex = ex.InnerException;
                }
            }
    
            var path = Path.Combine(SaveFolder, filename);
            using (var sw = new StreamWriter(path))
                await sw.WriteAsync(source);
        }
    
        async Task<String> GetSource(string location)
        {
            using (var client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(location);
            }
        }
    }
