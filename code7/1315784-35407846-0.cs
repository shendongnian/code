    public ActionResult LaunchSearch(string keyword, string keyword2, int chx, int pid, int fid)
    {
        using(var db = new AuditprinterDBEntities1())
        {
            var auditPrinter = db.AuditPrinter.Include(a => a.Pc).Include(a => a.PrintersConfig).Include(a => a.Users);
            
            // Do whatever you need to do and return result ...
        }
    }
