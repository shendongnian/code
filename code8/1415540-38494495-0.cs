    public List<PrinterDrivers> GetPrinterDriversFromCache()
        {
            using (dbPrintSimpleDataContext db = new dbPrintSimpleDataContext())
            {
                var q = (from p in db.GetTable<tblPrinterDriverCache>()
                        where p.CacheGUID == mostRecentCacheID()
                        group p by p.PrinterDriver into g
                        ).ToList().Select(g => new PrinterDrivers
                        {
                            DriverName = g.Key,
                            InstalledOn = g.Where(x => x.PrinterDriver == g.Key).Select(x => x.PrinterServer).ToList(),
                            Usable = (g.Count() == Properties.Settings.Default.PrintServers.Count)
                        });
                return q.ToList();
            }
        }
