    public static class DSL
    {
        public static T at<T>(Location location)
        {
            return (T)typeof(T).GetConstructor(new[]{typeof(Location)})?.Invoke(new object[] {location});
        }
    }
