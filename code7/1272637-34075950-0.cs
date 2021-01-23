    PropertyChangedEventHandler handler;
    switch (tableType)
    {
        case TableType.Attribute:
            handler = new PropertyChangedEventHandler(appTableConfigs_PropertyChanged);
            _attributeTableConfigs.PropertyChanged += handler;
            break;
        case TableType.Core:
            handler = new PropertyChangedEventHandler(appTableConfigs_PropertyChanged);
            _coreTableConfigs.PropertyChanged += handler;
            break;
        case TableType.Domain:
            handler = new PropertyChangedEventHandler(appTableConfigs_PropertyChanged);
            _domainTableConfigs.PropertyChanged += handler;
            break;
        case TableType.Configuration:
            handler = new PropertyChangedEventHandler(appTableConfigs_PropertyChanged);
            _configTableConfigs.PropertyChanged += handler;
            break;
        default:
            handler = new PropertyChangedEventHandler(appTableConfigs_PropertyChanged);
            _offlineTableConfigs.PropertyChanged += handler;
            break;
    }
