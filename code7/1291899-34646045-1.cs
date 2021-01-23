        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> iEnumerable) 
        { 
            return iEnumerable ?? Enumerable.Empty<T>();
        }
    }
