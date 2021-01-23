    private ManagerViewModel(IEnumerable<string> settings) : base(settings) {}
    public async Task<ManagerViewModel> CreateAsync(ISettingsProvider settingsProvider) {
        var settings = await settingsProvider.GetSettingsAsync();
        return new ManagerViewModel(settings);
    }
    // ....
    public async Task<IEnumerable<Settings>> GetSettingsAsync() {
        return await _service.GetSettings().Timeout(...).FirstAsync();
    }
