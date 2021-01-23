    public static class DataTableExtensions
    {
        public class DataRowValuesComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y)
            {
                if(ReferenceEquals(x, y))
                    return true;
                if (x == null || y == null)
                    return false;
                if (!ReferenceEquals(x.Table, y.Table))
                    return false; // different tables
                foreach (DataColumn column in x.Table.Columns)
                {
                    object v1 = x[column];
                    object v2 = y[column];
                    if (ReferenceEquals(v1, v2)) continue;
                    if (v1 == null || v2 == null) return false;
                    if (!v1.Equals(v2)) return false;
                }
                return true;
            }
            public int GetHashCode(DataRow obj)
            {
                if (obj == null) return int.MinValue;
                unchecked
                {
                    int hash = 19;
                    foreach (DataColumn column in obj.Table.Columns)
                    {
                        object value = obj[column];
                        hash = hash * 31 + (value?.GetHashCode() ?? 0);
                    }
                    return hash;
                }
            }
        }
        public static IEnumerable<DataRow> DistinctValues(this IEnumerable<DataRow> rows)
        {
            return rows.Distinct(new DataRowValuesComparer());
        }
    }
