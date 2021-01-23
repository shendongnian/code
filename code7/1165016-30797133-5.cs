    public static void CloneInto(this List<T> source, List<T> destination)
    {
        destination.Clear();
        destination.AddRange(source);
    }
