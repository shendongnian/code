        private Dictionary<string, List<int>> clone(Dictionary<string, List<int>>  map)
        {
            Dictionary<string, List<int>> clone = new Dictionary<string,  List<int>>(map.Count);
            foreach (var pair in map)
            {
                clone[pair.Key] = new List<int>(pair.Value);
            }
            return clone;
        }
        //And then call it from your code:
        getMaxNodeDepth(parent, listIndex, clone(paths));
