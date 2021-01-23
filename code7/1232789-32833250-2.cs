    private void LoadSettings()
    {
        _settings = _service.GetSettings
                            .Timeout(_expireTime, Observable.Return(Enumerable.Empty<string>()))
                            .FirstAsync()
                            .Wait();
    }
