      public static object ToDBNull(object value) {
            if (value == null) {
                return DBNull.Value;
            }
            else {
                return value;
            }
        }
