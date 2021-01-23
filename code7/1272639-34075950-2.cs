    PropertyChangedEventHandler handler = appTableConfigs_PropertyChanged;
    switch (tableType)
    {
        case TableType.Attribute:
            _attributeTableConfigs.PropertyChanged += handler;
            break;
        case TableType.Core:
            _coreTableConfigs.PropertyChanged += handler;
            break;
        case TableType.Domain:
            _domainTableConfigs.PropertyChanged += handler;
            break;
        case TableType.Configuration:
            _configTableConfigs.PropertyChanged += handler;
            break;
        default:
            _offlineTableConfigs.PropertyChanged += handler;
            break;
    }
