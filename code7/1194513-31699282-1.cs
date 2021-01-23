    public static class MyExtensionMethods
    {
        public static void SetValue<T>(this I<T> intf, T value)
        {
            intf.Set(value);
        }
    }
