    lock (UpdateLock)
    {
      if (_lastUpdate < DateTime.Now.AddSeconds(-5)) {
        Task.Run(() => {
          _liaQueueList = _db.liaQueue.Where(w => w.Stat == 0).ToList();
        }).Wait();
        _lastUpdate = DateTime.Now;
      }
    }
    return _liaQueueList.FirstOrDefault(w => w.Stat == 0 && w.Type != null || string.Equals(w.Type, sessionType));
