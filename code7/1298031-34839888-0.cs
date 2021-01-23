    public static Func<TObject, TKey> BuildKeySelector<TObject, TKey>(string propertyName)
    {
        return obj =>
        {
            var prop = typeof(TObject).GetProperty(propertyName, typeof(TKey));
            return (TKey) prop.GetValue(obj);
        };
    }
