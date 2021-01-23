    public static TResult Execute<TResult>()
    {
        var myArray = new List<object>() { 1, 2, 3 };
        Type entityType = typeof(TResult).GetElementType();
        var outputArray = Array.CreateInstance(entityType, myArray.Count);
        Array.Copy(myArray.ToArray(), outputArray, myArray.Count); //note, this will only work with reference conversions. If user defined cast operators are involved, this method will fail.
        return (TResult)(object)outputArray;
    }
