    [Fact]
    public void GoToConfigurationActivatesCorrectViewModel()
    {
        var configuration = new ConfigurationViewModel();
        var main = new MainViewModel(configuration);
        ScreenExtensions.TryActivate(main);
        main.GoToConfiguration();
        Assert.True(configuration.IsActive);
    }
