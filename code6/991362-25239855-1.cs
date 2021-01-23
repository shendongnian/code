    public void Dispose()
    {
        if (_browser != null)
        {
            _browser.Stop();
    
            if (!_browser.IsDisposed)
            {
                _browser.Dispose();
            }
        }
    }
