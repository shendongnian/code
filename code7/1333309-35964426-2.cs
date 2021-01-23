    public static class MultiCartesianExtension
    {
        public static IEnumerable<TInput[]> MultiCartesian<TInput>(this IEnumerable<IEnumerable<TInput>> input)
        {
            return input.MultiCartesian(x => x);
        }
        public static IEnumerable<TOutput> MultiCartesian<TInput, TOutput>(this IEnumerable<IEnumerable<TInput>> input, Func<TInput[], TOutput> selector)
        {
            var inputList = input.ToList();
            var buffer = new TInput[inputList.Count];
            var results = MultiCartesianInner(inputList, buffer, 0);
            var transformed = results.Select(selector);
            return transformed;
        }
        private static IEnumerable<TInput[]> MultiCartesianInner<TInput>(IList<IEnumerable<TInput>> input, TInput[] buffer, int depth)
        {
            foreach (var current in input[depth])
            {
                buffer[depth] = current;
                if (depth == buffer.Length - 1)
                {
                    var bufferCopy = (TInput[])buffer.Clone();
                    yield return bufferCopy;
                }
                else
                {
                    foreach (var a in MultiCartesianInner(input, buffer, depth + 1))
                    {
                        yield return a;
                    }
                }
            }
        }
