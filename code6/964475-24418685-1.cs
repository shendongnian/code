    public static class Seq
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> seq)
        {
            return seq ?? Enumerable.Empty<T>();
        }
    }
    
    return this.Trucks.EmptyIfNull().Any() || this.Cars.EmptyIfNull().Any()
