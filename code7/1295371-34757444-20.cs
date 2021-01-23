            lock (map)
            {
                if (!map.TryGetValue(fileInfo, out pendingTask))
                {
                    pendingTask = FileData.CreateAsync(fileInfo);
                    map.Add(fileInfo, pendingTask);
                }
            }
            var data = await pendingTask;
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
