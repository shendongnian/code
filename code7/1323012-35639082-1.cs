    using System.Reactive.Linq;
    public class T2
    {
        public string Name;
    }
    public class T
    {
        public IEnumerable<T2> t2Collection;
        public IEnumerable<T> tCollection;
    }
    
    public T2 Find(IEnumerable<T> primaryCollection, string searchValue)
    {
        T2 result = null;
        Observable.Generate(
                new 
                {
                    currentCollection = primaryCollection, 
                    searchedT2 = default(T2) 
                },
                state => state.searchedT2 == default(T2),
                state => new
                {
                currentCollection = state.currentCollection.SelectMany(t => t.tCollection),
                searchedT2 = state.currentCollection.SelectMany(t => t.t2Collection).FirstOrDefault(t2 => t2.Name == searchValue)
                },
                state => state.searchedT2
                ).Subscribe(t2=>result=t2);
        return result;
        }
	
