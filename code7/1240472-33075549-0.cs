    public SQLiteConnection(ISQLitePlatform sqlitePlatform
                            , string databasePath
                            , SQLiteOpenFlags openFlags
                            , bool storeDateTimeAsTicks = true
                            , IBlobSerializer serializer = null
                            , IDictionary<string, TableMapping> tableMappings = null
                            , IDictionary<Type, string> extraTypeMappings = null
                            , IContractResolver resolver = null);
