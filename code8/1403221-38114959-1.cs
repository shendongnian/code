    private static Dictionary<string, Func<IEfBulkInsertProvider>> Providers
    {
        get
        {
            //commented pice of code does not exist at Nuget Package
            //lock (ProviderInitializerLockObject)
            //{
                if (_providers == null)
                {
                    _providers = new Dictionary<string, Func<IEfBulkInsertProvider>>();
                    // bundled providers
                    Register<EfSqlBulkInsertProviderWithMappedDataReader>("System.Data.SqlClient.SqlConnection");
                    //Register<EfSqlCeBulkiInsertProvider>("System.Data.SqlServerCe.4.0");
                }
            //}
            return _providers;
        }
    }
