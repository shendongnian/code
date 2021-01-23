    public class UnzipResult<T>{
		private readonly IEnumearator<T> _enumerator;
		private readonly Func<T, bool> _filter;
		
		private readonly Queue<T> _nonMatching = new Queue<T>();
		private readonly Queue<T> _matching = new Queue<T>();
		
		public IEnumerable<T> Matching {get{
			if(_matching.Count > 0)
				yield return _matching.Dequeue();
			else {
				while(_enumerator.MoveNext()){
				if(_filter(_enumerator.Current))
					yield return _enumerator.Current;
				else 
					_nonMatching.Enqueue(_enumerator.Current);
				}
				yield break;
			}
		}}
		
		public IEnumerable<T> Rest {get{
			if(_matching.Count > 0)
				yield return _nonMatching.Dequeue();
			else {
				while(_enumerator.MoveNext()){
				if(!_filter(_enumerator.Current))
					yield return _enumerator.Current;
				else 
					_matching.Enqueue(_enumerator.Current);
				}
				yield break;
			}
		}}
		
		public UnzipResult(IEnumerable<T> source, Func<T, bool> filter){
			_enumerator = source.GetEnumerator();
			_filter = filter;
		}
	}
	public static UnzipResult<T> Unzip(this IEnumerable<T> source, Func<T,bool> filter){
		return new UnzipResult(source, filter);
	}
