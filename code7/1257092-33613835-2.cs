    public static class EvenMoreLinq
    {
        /// <summary>
        /// Combines mulitiple sequences of elements into a single sequence, 
        /// by first pivoting all n-th elements across sequences 
        /// into a new sequence then applying resultSelector to collapse it
        /// into a single value and then collecting all those 
        /// results into a final sequence. 
        /// NOTE: The length of the resulting sequence is the length of the
        ///       shortest source sequence.
        /// Example (with sum result selector):
        ///  S1   S2   S2    |  ResultSeq
        ///   1    2    3    |          6 
        ///   5    6    7    |         18
        ///  10   20   30    |         60
        ///   6    -    7    |          -
        ///   -         -    |          
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="source">A sequence of sequences to be multi-ziped</param>
        /// <param name="resultSelector">function to compress a projected n-th column across sequences into a single result value</param>
        /// <returns>A sequence of results returned by resultSelector</returns>
        public static IEnumerable<TResult> MultiZip<TSource, TResult>
                                      this IEnumerable<IEnumerable<TSource>> source, 
                                      Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (resultSelector == null) throw new ArgumentNullException("resultSelector");
            var iterators = source.Select(s => s.GetEnumerator()).ToArray();
            try
            {
                while (iterators.All(e => e.MoveNext()))
                    yield return resultSelector(iterators.Select(e => e.Current));
            }
            finally
            {
                if (iterators != null)
                    foreach (var iterator in iterators) iterator.Dispose();
            }
        }
    }
