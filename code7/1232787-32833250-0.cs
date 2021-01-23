    private void LoadSettings()
    {
        _service.GetSettings
                    .Timeout(_expireTime, Observable.Return(Enumerable.Empty<string>()))
                    .FirstAsync()
                    .Wait();
        _service.GetSettings.Subscribe(LoadSettingsCompleted);
    }
