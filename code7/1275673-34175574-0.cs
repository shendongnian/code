        public int GetPreviousData()
        {
            Task.Run((Func<int>)getData).ContinueWith(t => _cachedData = t.Result);            
            return _cachedData; // some previous value
        }
