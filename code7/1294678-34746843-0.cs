    public static class DataGridViewExtensions
    {
        public static void AddRange(this DataGridViewRowCollection collection, IEnumerable<object[]> rows)
        {
            foreach (object[] item in rows)
            {
                collection.Add(item);
            }
        }
    }
