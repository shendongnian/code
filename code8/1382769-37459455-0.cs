    public class MyContainer<T> where T : IComparable<T>, IMyTest<T> 
    {
        public T SumBiggestAndSmallest(IEnumerable<T> items)
        {
            var ordered = items.OrderBy(x => x)
                               .ToList();
            return ordered.First().Add(ordered.First(), ordered.Last());
        }
    }
