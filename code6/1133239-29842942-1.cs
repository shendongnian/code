    static class Extensions
    {
        public static DataStruct EmptyIfNull(this IEnumerable<DataStruct> collection) {
            if (collection == null) {
                return return new DataStruct[0];
            }
            return collection;
        }
    }
