        public async Task<ICollection<FileData>> ProcessAsync(IEnumerable<FileInfo> files)
        {
            var map = new Dictionary<FileInfo, FileData>();
            var tasks = files.Select(it => LoadFileDataAsync(it, map));
            return await Task.WhenAll(tasks);
        }
        static async Task<FileData> LoadFileDataAsync(FileInfo fileInfo, Dictionary<FileInfo, FileData> map)
        {
           // Load recursively FileData elements for all children 
           // storing the result in the map.
            FileData data;
            lock (map)
            {
                if (map.TryGetValue(fileInfo, out data))
                {
                    return data;
                }
            }
            data = await FileData.CreateAsync(fileInfo);
            lock (map)
            {
                if (map.ContainsKey(fileInfo))
                {
                    return map[fileInfo];
                }
                map.Add(fileInfo, data);
            }
            foreach(var item in data.DependsUpon)
            {
                // Recursively load data for all child items
                await LoadFileDataAsync(item, map);
            }
            // Assign an iterator traversing through the dependency graph
            // Note: parameters are captured by reference.
            data.Dependencies = ExpandDependencies(data.DependsUpon, map);
            return data;
        }
        static IEnumerable<FileInfo> ExpandDependencies(ISet<FileInfo> directDependencies, Dictionary<FileInfo, FileData> map)
        {
            // Depth-first graph traversal
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
