    public class PrintersCache
    {
        public static AuditprinterDBEntities1 db = new AuditprinterDBEntities1();
        static PrintersCache()
        {
            AuditPrinterCache = db.AuditPrinter
                                .Include(a => a.Pc)
                                .Include(a => a.PrintersConfig)
                                .Include(a => a.Users);
        }
        public static IQueryable<AuditPrinter> AuditPrinterCache
        {
            get; private set;
        }
    }
