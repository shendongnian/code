    public static void SetValueForPropertyIf<T>(Predicate<object>[] conditions, ref T property, T value) {
        foreach (var predicate in conditions) {
            if (!predicate(null)) {
                return
            }
        }
        property = value;
    }
