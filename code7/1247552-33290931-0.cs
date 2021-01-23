    public static class DataRowExtensions
    {
        public static T TryGetField<T>(this DataRow row, string fieldName)
        {
            return row.Table.Columns.Contains(fieldName) ? row.Field<T>(fieldName) : default(T);
        }
    }
