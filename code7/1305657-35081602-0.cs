        public static IEnumerable<ElementInfo> Method<T>(
            this IEnumerable<T> collection)
            where T : ITest
        {
            return collection.ToInfoObjects();
        }
        public static IEnumerable<ElementInfo> ToInfoObjects<T>(
            this IEnumerable<T> collection)
        {
            return collection.Select(item => new ElementInfo());
        }
