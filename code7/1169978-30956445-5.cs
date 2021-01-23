    private class En : IEnumerator<object>
    {
      private object _current;
      private int _state;
      public MyList _this;
      public int _index;
      public bool MoveNext()
      {
        int state = _state;
        switch(state)
        {
          case 0:
            _state = -1;
            _index = 0;
            break;
          case 1:
            _state = -1;
            if(++_index >= _this.array.Length)
              return false;
            break;
          default:
            return false;
        }
        _current = _this.array[_index];
        _state = 1;
        return true;
      }
      public object Current
      {
        get { return _current; }
      }
      public void Reset()
      {
        throw new NotSupportedException();
      }
      public void Dispose()
      {
      }
      object IEnumerator.Current
      {
        get { return _current; }
      }
      public En(int state)
      {
        _state = state;
      }
    }
    public IEnumerator GetEnumerator()
    {
      var en = new En(0);
      en._this = this;
      return en;
    }
