    public static log4net.ILog Log { get; private set; }
    static void Main(string[] args)
    {
        log4net.Config.XmlConfigurator.Configure();
        Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
