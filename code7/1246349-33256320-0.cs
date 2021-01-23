    public dynamic GetValue()
    {
        return typeof(ConfigurationItem)
            .GetMethod("GetReturnValue", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .MakeGenericMethod(type)
            .Invoke(this, new object[] { });
    }
    private T GetReturnValue<T>()
    {
        return (T)Convert.ChangeType(Value, type);
    }
