    public IEnumerator<TResult> GetEnumerator()
    {
        if(_list) != null
            foreach(var item in _list)
            {
                yield return item;
            }
        if(_asyncCursor) != null
            for (; _asyncCursor.MoveNextAsync().Result;)
            {
                foreach (var result in _asyncCursor.Current)
                {
                    yield return result;
                }
            }
        }
