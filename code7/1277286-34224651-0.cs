    _timer.Tick += async (sender, args) =>
    {
        var timeSpan = _nextRun - DateTime.Now;
        if (timeSpan.Seconds >= 0)
        {
            UpdateCountdownMessage(string.Format("{0:00}:{1:00}:{2:00} to next run.", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds));
        }
        else
        {
            _timer.Enabled = false;
            try
            {
                await Task.Run(async () =>
                {
                    await _runLock.WaitAsync();
                    try { RunJobs(_batch1Jobs); }
                    finally { _runLock.Release(); }
                });
            }
            finally { _timer.Enabled = true; }
        }
    };
