    public class ResettingEnumerable<T> : IEnumerable<T> {
    	private readonly Func<IEnumerable<T>> _enumerableFetcher;
    
    	public ResettingEnumerable(Func<IEnumerable<T>> enumerableFetcher) {
    		_enumerableFetcher = enumerableFetcher;
    	}
    
    	public IEnumerator<T> GetEnumerator() => _enumerableFetcher().GetEnumerator();
    	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
