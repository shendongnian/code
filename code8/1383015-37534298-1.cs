    public void AddToVal(int num)
    {
        lock (_syncObj)
        {
            _i += num;
            if (_i == 5)
            {
                _event.Reset();
                return;
            }
            _event.Set();
        }
    }
    // and in the waitable thread:
    _event.wait();
