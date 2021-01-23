    int dop = Environment.ProcessorCount;
    ServicePointManager.MaxServicePoints = 4;
    ServicePointManager.MaxServicePointIdleTime = 10000;
    ServicePointManager.UseNagleAlgorithm = true;
    ServicePointManager.Expect100Continue = false;
    ServicePointManager.DefaultConnectionLimit = dop * 10;
    
    ServicePoint sp = ServicePointManager.FindServicePoint ( new Uri ( AppConfig.ESLBridgeURL ) );
