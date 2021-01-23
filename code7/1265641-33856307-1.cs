    public static IEnumerable<TResult> CreateDeferredIEnumerable(IAsyncCursor<TResult> _asyncCursor)
    {
        if (_asyncCursor != null)
        {
            using (_asyncCursor) { //This is key
            for (; _asyncCursor.MoveNextAsync().Result;)
            {
                foreach (var result in _asyncCursor.Current)
                {
                    yield return result;
                }
            }
            }
        }
    }
