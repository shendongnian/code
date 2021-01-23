    public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> list)
    {
      return list.GroupBy(item => item).SelectMany(group => group.Skip(1));
    }
    public static bool HasDuplicates<T>(this IEnumerable<T> list)
    {
        return list.GetDuplicates().IsNotEmpty();
    }
