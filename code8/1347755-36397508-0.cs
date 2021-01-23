    internal static class ConvertExtension {
        public static bool ToBoolean(this object value) {
            if (value == null or DBNull.Value.Equals(value)) return false;
            if (value is bool) return (bool)value;
            string obj =  value.ToString(CultureInfo.InvariantCulture);
            return !(string.IsNullOrEmpty(obj) 
                || string.Equals(obj, "0") 
                || string.Equals("false", obj, StringComparison.OrdinalIgnoreCase));
        }
    }
