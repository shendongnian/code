    connectionSettings = new ConnectionSettings(connectionUri);
    connectionSettings.SetJsonSerializerSettingsMo‌​difier(
        p => p.Converters.Add(new AssetTypeConverter())
    );
    _elasticClient = new ElasticClient(connectionSettings);
