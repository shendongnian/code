    private static Dictionary<string, object> FlattenDimensions(dynamic[] dimensions)
        {
            var flattened = new Dictionary<string, object>();
            foreach (var dimension in dimensions)
            {
                var dict = (IDictionary<string, object>)dimension;
                foreach (var item in dict)
                {
                    flattened.Add(item.Key, item.Value);
                }
            }
            return flattened;
        }
