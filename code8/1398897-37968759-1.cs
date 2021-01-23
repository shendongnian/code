    public static class ExtendedLinq
    {
        public static bool All<T>(this IEnumerable<T> source, params Func<T, bool>[] conditions)
        {
            foreach (var condition in conditions)
                if (!source.Any(condition))
                    return false;
    
            return true;
        }
    }
