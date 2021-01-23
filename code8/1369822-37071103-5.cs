    public sealed class IncreasingSubsetFinder<T> where T: IComparable<T>
    {
        public static IEnumerable<IEnumerable<T>> Find(IEnumerable<T> numbers)
        {
            return new IncreasingSubsetFinder<T>().find(numbers.GetEnumerator());
        }
        IEnumerable<IEnumerable<T>> find(IEnumerator<T> iter)
        {
            if (!iter.MoveNext())
                yield break;
            while (!done)
                yield return increasingSubset(iter);
        }
        IEnumerable<T> increasingSubset(IEnumerator<T> iter)
        {
            while (!done)
            {
                yield return prev = iter.Current;
                if ((done = !iter.MoveNext()) || iter.Current.CompareTo(prev) <= 0)
                    yield break;
            }
        }
        T    prev;
        bool done;
    }
