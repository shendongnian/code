    public class PrintersCache
    {
        public static AuditprinterDBEntities1 db = new AuditprinterDBEntities1();
        static PrintersCache()
        {
            AuditPrinterCache = db.AuditPrinter
                                .Include(a => a.Pc)
                                .Include(a => a.PrintersConfig)
                                .Include(a => a.Users).ToList;
        }
        public static List<AuditPrinter> AuditPrinterCache
        {
            get; private set;
        }
    }
