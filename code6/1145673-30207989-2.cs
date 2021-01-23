    public static class EnumerableExtensions {
        public delegate TResult Func<T, TResult>(T t);
        public static T[] Where<T>(IEnumerable<T> e, Func<T, bool> func) {
            IList<T> result = new List<T>();
            foreach (T each in e) {
                if (func(each)) {
                    result.Add(each);
                }
            }
            T[] returnValue = new T[result.Count];
            result.CopyTo(returnValue, 0);
            return returnValue;
        }
    }
