    public static class DataRowEx
    {
        public static string String(this DataRow row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return null;
            return obj.ToString();
        }
        public static Int32 Int32(this DataRow row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return 0;
            return (Int32)obj;
        }
        public static Decimal Decimal(this DataRow row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return 0;
            return Convert.ToDecimal(obj);
        }
        public static Double Double(this DataRow row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return 0;
            return Convert.ToDouble(obj);
        }
        public static Single Single(this DataRow row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return 0;
            return Convert.ToSingle(obj);
        }
        public static bool Bool(this DataRow row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return false;
            if (obj is int)
                return (int) obj != 0;
            return (bool)obj;
        }
        public static DateTime DateTime(this DataRow row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return System.DateTime.MinValue;
            return (DateTime)obj;
        }
        public static object ToType(this DataRow row, Type targetType, string columnName)
        {
            if (targetType == typeof(Int32))
                return row.Int32(columnName);
            if (targetType == typeof(bool))
                return row.Bool(columnName);
            if (targetType == typeof(DateTime))
                return row.DateTime(columnName);
            if (targetType == typeof (Decimal))
                return row.Decimal(columnName);
            if (targetType == typeof(Single))
                return row.Double(columnName);
            if (targetType == typeof(Double))
                return row.Double(columnName);
            if (targetType == typeof(string))
                return row.String(columnName);
            return row.String(columnName);
        }
        public static string String(this DataRowView row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return null;
            return obj.ToString();
        }
        public static Int32 Int32(this DataRowView row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return 0;
            return (Int32)obj;
        }
        public static Decimal Decimal(this DataRowView row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return 0;
            return (Decimal)obj;
        }
        public static Double Double(this DataRowView row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return 0;
            return (Double)obj;
        }
        public static Single Single(this DataRowView row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return 0;
            return (Single)obj;
        }
        public static bool Bool(this DataRowView row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return false;
            return (bool)obj;
        }
        public static DateTime DateTime(this DataRowView row, string columnName)
        {
            object obj = row[columnName];
            if (obj is DBNull)
                return System.DateTime.MinValue;
            return (DateTime)obj;
        }
        public static object ToType(this DataRowView row, Type targetType, string columnName)
        {
            if (targetType == typeof(Int32))
                return row.Int32(columnName);
            if (targetType == typeof(bool))
                return row.Bool(columnName);
            if (targetType == typeof(DateTime))
                return row.DateTime(columnName);
            if (targetType == typeof(Decimal))
                return row.Decimal(columnName);
            if (targetType == typeof(Double))
                return row.Double(columnName);
            if (targetType == typeof(Single))
                return row.Single(columnName);
            return row.String(columnName);
        }
    }
