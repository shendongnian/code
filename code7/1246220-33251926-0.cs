    public static class DataRecordExtensions
    {
        public static ISet<string> GetFieldNames(this IDataRecord dr, StringComparer comparer)
        {
            var sequence = Enumerable.Range(0, dr.FieldCount)
                                     .Select(i => dr.GetName(i));
            return new HashSet<string>(sequence, comparer);
        }
    }
