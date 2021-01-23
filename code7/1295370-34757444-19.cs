        public async Task<ICollection<FileData>> ProcessAsync(IEnumerable<FileInfo> files)
        {
            var map = new Dictionary<FileInfo, Task<FileData>>();
            var tasks = files.Select(it => LoadFileDataAsync(it, map));
            return await Task.WhenAll(tasks);
        }
        static async Task<FileData> LoadFileDataAsync(FileInfo fileInfo, Dictionary<FileInfo, Task<FileData>> map)
        {
           // Load recursively FileData elements for all children 
           // storing the result in the map.
