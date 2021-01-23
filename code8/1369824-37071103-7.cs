    public sealed class IncreasingSubsetFinder<T> where T: IComparable<T>
    {
        T  prev;
        bool done;
        readonly IEnumerator<T> iter;
        IncreasingSubsetFinder(IEnumerable<T> numbers)
        {
            iter = numbers.GetEnumerator();
        }
        public static IEnumerable<IEnumerable<U>> Find<U>(IEnumerable<U> numbers) where U: IComparable<U>
        {
            return new IncreasingSubsetFinder<U>(numbers).find();
        }
        IEnumerable<IEnumerable<T>> find()
        {
            if (!iter.MoveNext())
                yield break;
            while (!done)
                yield return increasingSubset();
        }
        IEnumerable<T> increasingSubset()
        {
            while (!done)
            {
                yield return prev = iter.Current;
                if ((done = !iter.MoveNext()) || iter.Current.CompareTo(prev) <= 0)
                    yield break;
            }
        }
    }
