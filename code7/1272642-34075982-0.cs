    switch (tableType)
            {
                case TableType.Attribute:
                    _attributeTableConfigs = new AppTableConfigCollection(_db, AppTableConfigCollection.ATTRIBUTE);
                    _attributeTableConfigs.PropertyChanged += new PropertyChangedEventHandler(appTableConfigs_PropertyChanged);
                    break;
                case TableType.Core:
                    _coreTableConfigs = new AppTableConfigCollection(_db, AppTableConfigCollection.CORE);
                    _coreTableConfigs.PropertyChanged += new PropertyChangedEventHandler(appTableConfigs_PropertyChanged)
                    break;
                case TableType.Domain:
                    _domainTableConfigs = new AppTableConfigCollection(_db, AppTableConfigCollection.DOMAIN);
                    _domainTableConfigs.PropertyChanged += new PropertyChangedEventHandler(appTableConfigs_PropertyChanged)
                    break;
                case TableType.Configuration:
                    _configTableConfigs = new AppTableConfigCollection(_db, AppTableConfigCollection.CONFIG);
                    _configTableConfigs.PropertyChanged += new PropertyChangedEventHandler(appTableConfigs_PropertyChanged)
                    break;
                default:
                    _offlineTableConfigs = new AppTableConfigCollection(_db, AppTableConfigCollection.OFFLIINE);
                    _offlineTableConfigs.PropertyChanged += new PropertyChangedEventHandler(appTableConfigs_PropertyChanged);
                    break;
            }
