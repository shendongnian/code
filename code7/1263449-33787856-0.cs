	public sealed class DeferredResultCollection<TResult> : IEnumerable<TResult>, IDisposable
	{
		private readonly IAsyncCursor<TResult> _asyncCursor;
		private readonly ICollection<TResult> _results;
	
		public DeferredResultCollection(IAsyncCursor<TResult> asyncCursor)
		{
			if (asyncCursor == null)
				throw new ArgumentNullException(nameof(asyncCursor));
				
			_asyncCursor = asyncCursor;
		}
		
		public DeferredResultCollection(ICollection<TResult> results)
		{
			if (results == null)
				throw new ArgumentNullException(nameof(results));
				
			_results = results;
		}
	
		public IEnumerator<TResult> GetEnumerator()
		{
			return _results != null
				? _results.GetEnumerator()
				: GetAsyncCursorEnumerator();
		}
		
		private IEnumerator<TResult> GetAsyncCursorEnumerator()
		{
			for (; _asyncCursor.MoveNextAsync().Result;)
			{
				foreach (var result in _asyncCursor.Current)
				{
					yield return result;
				}
			}
		}
	
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	
		public void Dispose()
		{
			if (_asyncCursor != null)
			{
				_asyncCursor.Dispose();
			}
		}
	}
