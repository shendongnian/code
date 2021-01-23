    public static T CastValue<T>(object value) {
        if (value == null || value is DBNull) {
			return default(T);
		}
		if (value is T) {
			return (T)value;
		}
		Type t = typeof(T);
		t = (Nullable.GetUnderlyingType(t) ?? t);
		if (typeof(IConvertible).IsAssignableFrom(t) && typeof(IConvertible).IsAssignableFrom(value.GetType())) {
			return (T)Convert.ChangeType(value, t);
		}
		return default(T);
	}
