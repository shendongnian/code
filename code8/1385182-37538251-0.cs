    public void Initialize(ILog log, AppSettings settings)
    {
        Initialize(log, settings, DbDatasourceFactory.CreateHrdbDatasource(settings.HrdbConnectionString);
    }
    // Unit-test this method,
    internal void Initialize(ILog log, AppSettings settings, HrdbDataSource hrdbDataSource)
    {
        _log = log;
        _hrdb = hrdbDataSource;
        _processor = new K2Processor(settings.SettlePaymentWorkflow);
        _sunFolderPath = settings.SunSystemExcelFolderPath;
    }
