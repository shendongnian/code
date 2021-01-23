    [Test]
    public void SomeTest()
    {
        CurrentAppSettings.Instance = () => new SimpleKeyValueAppSettings(new Dictionary<string, string>());
        // ...
    }
