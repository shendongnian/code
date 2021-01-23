    public class Keyed : KeyedCollection<string, string>
    {
        public Keyed(IEqualityComparer<string> comparer) : base(comparer)
        {
    
        }
    
        protected override string GetKeyForItem(string item)
        {
            return item;
        }
    }
