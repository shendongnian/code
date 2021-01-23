    var q = db.GetTable<tblPrinterDriverCache>()
                .Where(p => p.CacheGUID == mostRecentCacheID())
                .Select(o => new { DriverName = o.DriverName, PrintServer = o.PrintServer })
                .GroupBy(g => g.DriverName)
                .ToList()
                .Select(g => new PrinterDrivers
                    {
                        DriverName = g.Key,
                        InstalledOn = g.Select(p => p.PrinterServer).ToList(),
                        Usable = (g.Count() == Properties.Settings.Default.PrintServers.Count)
                    }
                )
                .ToList();
