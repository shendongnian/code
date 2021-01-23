    private class Iterator : IEnumerable<object>, IEnumerator<object>
    {
      private int _state;
      private int _threadId = Environment.CurrentManagedThreadId;
      private object _current;
      private float _value;
      int i;
      public Iterator(float value)
      {
        _value = value;
      }
      public object Current‎
      {
        get { return _current; }
      }
      object IEnumerator.Current
      {
        get { return _current; }
      }
      public IEnumerator<object> GetEnumerator()
      {
        // If we're on the same thread and its the first call, reuse this object as the enumerator
        // otherwise create a fresh one for new call (so we don't have buggy overlaps) or a different
        // thread (to avoid a race on that first call).
        Iterator iter = _state == 0 && _threadId == Environment.CurrentManagedThreadId ? this : new Iterator(_value);
        iter._state = 1;
        return iter;
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
      public bool MoveNext()
      {
        switch(_state)
        {
          case 1:
            i = 1;
            _state = 2;
            goto case 2;
          case 2:
            if (i <= 10)
            {
              Debug.Log(_value);
              _current = null;
              ++i;
              return true;
            }
            _state = -1;
            break;
        }
        return false;
      }
      public void Dispose()
      {
      }
      public void Reset()
      {
        throw new NotSupportedException();
      }
    }
    private IEnumerator test(float value)
    {
      return new Iterator(value);
    }
