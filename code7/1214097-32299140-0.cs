    public Array ToEnumArray<T>(Type type, T[] arr)
    {
        if (!typeof(Enum).IsAssignableFrom(type))
            throw new ArgumentException(String.Format("Type '{0}' is not an Enum", type));
        var result = Array.CreateInstance(type, arr.Length);
        for (int i = 0, len = arr.Length; i < len; ++i)
        {
            var arrValue = Enum.ToObject(type, arr[i]);
            result.SetValue(arrValue, i);
        }
        return result;
    }
