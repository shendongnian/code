        public async Task<ICollection<FileData>> ProcessAsync(IEnumerable<FileInfo> files)
        {
            var map = new Dictionary<FileInfo, FileData>();
            var tasks = files.Select(it => LoadFileDataAsync(it, map));
            return await Task.WhenAll(tasks);
        }
       // Load recursively FileData elements for all children 
       // storing the result in the map.
        static async Task<FileData> LoadFileDataAsync(FileInfo fileInfo, Dictionary<FileInfo, FileData> map)
        {
            var data = await FileData.CreateAsync(fileInfo);
            lock (map)
            {
                map.Add(fileInfo, data);
            }
            data.Dependencies = ExpandDependencies(data.DependsUpon, map);
            foreach(var item in data.DependsUpon)
            {
                if (map.ContainsKey(item))
                {
                    continue;
                }
                // Recursively load data for all child items
                await LoadFileDataAsync(item, map);
            }
            return data;
        }
        static IEnumerable<FileInfo> ExpandDependencies(ISet<FileInfo> directDependencies, Dictionary<FileInfo, FileData> map)
        {
            var visited = new HashSet<FileInfo>(map.Comparer); // check for duplicates
            var stack = new Stack<FileInfo>();
            foreach(var item in directDependencies)
            {
                stack.Push(item);
            }
            while(stack.Count > 0)
            {
                var info = stack.Pop();
                if (visited.Add(info))
                {
                    yield return info;
                    var data = map[info];
                    foreach (var child in data.DependsUpon)
                    {
                        stack.Push(child);
                    }
                }
            }
        }
