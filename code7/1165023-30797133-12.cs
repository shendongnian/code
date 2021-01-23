    public static void CloneInto(this List<T> source, List<T> destination)
    {
        destination.Capacity = 0; // or destination.Clear();
        destination.AddRange(source);
    }
