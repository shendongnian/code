    static class Extensions
    {
        public static DataStruct Filter(this IEnumerable<DataStruct> collection) {
            if (collection == null) {
                return null; // or throw if you like
            }
            return collection
                .Where(k => k.number ==2)
                .FirstOrDefault();
        }
    }
