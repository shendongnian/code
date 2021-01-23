    public static void Loop<T>(Action<T> action)
    {
        // generate some T value
        T value = GetValue<T>();
        // call action with a T parameter
        action(value);
    }
