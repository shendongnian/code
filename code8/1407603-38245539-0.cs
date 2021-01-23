    public class GroupedResult<TKey, TElement>
    {
        public TKey Key { get; set; }
    
        private readonly IEnumerable<TElement> source;
    
        public GroupedResult(TKey key, IEnumerable<TElement> source)
        {
            this.source = source;
            this.Key = key;
        }
    
        public GroupedResult<TKey, object> Cast()
        {
            return new GroupedResult<TKey, object>(Key, source.Cast<object>());
        }
    }
    public class Bacon
    { 
    }
    static void Main(string[] args)
    {
    
       var list = new List<GroupedResult<string, Bacon>>
       {
            new GroupedResult<string, Bacon>("1", new List<Bacon>()),
            new GroupedResult<string, Bacon>("2", new List<Bacon>())
        };
    
        // var result = list.Cast<GroupedResult<string, object>>().ToList();
        List<GroupedResult<string,object>> result = list.Select(B => B.Cast()).ToList();
    }
