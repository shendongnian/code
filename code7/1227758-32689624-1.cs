    public bool HasAllEmptyProperties()
    {
        var type = GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var hasProperty = properties.Select(x => x.GetValue(this, null))
                                    .Any(y => y != null && !String.IsNullOrWhiteSpace(y.ToString()));
        return !hasProperty;
    }
