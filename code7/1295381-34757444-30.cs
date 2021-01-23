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
            Task<FileData> pendingTask;
            bool isNew;
         
            lock (map)
            {
                isNew = !map.TryGetValue(fileInfo, out pendingTask);
                if (isNew)
                {
                    pendingTask = FileData.CreateAsync(fileInfo);
                    map.Add(fileInfo, pendingTask);
                }
            }
            var data = await pendingTask;
            if (isNew)
            {
               // Assign an iterator traversing through the dependency graph
               // Note: parameters are captured by reference.
               data.Dependencies = ExpandDependencies(data.DependsUpon, map);
               if (data.DependsUpon.Count > 0)
               {
                  // Recursively load child items
                  var tasks = data.DependsUpon.Select(it => (Task)LoadFileDataAsync(it, map));
                  await Task.WhenAll(tasks);
               }
            }
            return data;
        }
        static IEnumerable<FileInfo> ExpandDependencies(ISet<FileInfo> directDependencies, Dictionary<FileInfo, Task<FileData>> map)
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
                    var data = map[info].Result;
                    foreach (var child in data.DependsUpon)
                    {
                        stack.Push(child);
                    }
                }
            }
        }
