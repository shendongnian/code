        public bool StartRequestIfAllowed
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    var nowTx = DateTime.Now.Ticks;
                    if (_requestsTx.Count(tx => nowTx - tx < _interval.Ticks) < _maxLimit)
                    {
                        _requestsTx.Add(DateTime.Now.Ticks);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }
