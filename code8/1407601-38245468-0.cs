    public interface IGroupResult<TKey, out TElement>
    {
        TKey Key { get; set; }
    }
    public class GroupedResult<TKey, TElement> : IGroupResult<TKey, TElement>
    {
        public TKey Key { get; set; }
        private readonly IEnumerable<TElement> source;
        public GroupedResult(TKey key, IEnumerable<TElement> source)
        {
            this.source = source;
            this.Key = key;
        }
    }
    public class Bacon
    {
    }
