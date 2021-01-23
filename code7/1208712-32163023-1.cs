    public static class JsonExtensions
    {
        public static void MoveTo(this JToken token, JObject newParent)
        {
            if (newParent == null)
                throw new ArgumentNullException();
            var toMove = token.AncestorsAndSelf().OfType<JProperty>().First(); // Throws an exception if no parent property found.
            if (toMove.Parent != null)
                toMove.Remove();
            newParent.Add(toMove);
        }
    }
    public static class RecursiveEnumerableExtensions
    {
        static bool ContainsNonNullKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary == null)
                throw new ArgumentNullException();
            return key == null ? false : dictionary.ContainsKey(key); // Dictionary<int?, X> throws on ContainsKey(null)
        }
        public static IEnumerable<TResult> ToTree<TInput, TKey, TResult>(
            this IEnumerable<TInput> collection,
            Func<TInput, TKey> idSelector,
            Func<TInput, TKey> parentIdSelector,
            Func<TInput, TResult> nodeSelector,
            Action<TResult, TResult> addMethod)
        {
            if (collection == null || idSelector == null || parentIdSelector == null || nodeSelector == null || addMethod == null)
                throw new ArgumentNullException();
            var list = collection.ToList(); // Prevent multiple enumerations of the incoming enumerable.
            var dict = list.ToDictionary(i => idSelector(i), i => nodeSelector(i));
            foreach (var input in list.Where(i => dict.ContainsNonNullKey(parentIdSelector(i))))
            {
                addMethod(dict[parentIdSelector(input)], dict[idSelector(input)]);
            }
            return list.Where(i => !dict.ContainsNonNullKey(parentIdSelector(i))).Select(i => dict[idSelector(i)]);
        }
    }
