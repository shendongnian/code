        IObservable<Tuple<Entity, bool>> Replace(IDictionary<Entity, Entity> Map)
        {
            Task<Tuple<Entity, bool>>[] tasks = new Task<Tuple<Entity, bool>>(Map.Count);
            int i = 0;
            foreach (var kvp in Map)
            {
                tasks[i++] = ReplaceAsync(kvp.Key, kvp.Value);
            }
            return tasks
                .Select(x => x.ToObservable())
                .Merge();   // or use .Concat for sequential execution
        }
