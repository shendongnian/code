        public Dictionary<Type, List<List<dynamic>>> GroupListsByType(List<List<dynamic>> lists)
        {
            var types = lists.Select(list => list.GetType().GenericTypeArguments[0]).Distinct().ToList();
            var grouped = new Dictionary<Type, List<List<dynamic>>>();
            types.ForEach(type =>
            {
                grouped.Add(type, new List<List<dynamic>>());
                grouped[type].AddRange(lists.Where(list=>list.GetType().GenericTypeArguments[0] == type));
            });
            return grouped;
        }
