    // Initializes your query
    var query = PrintersCache.GetAuditPrinterCache().Where(a => a.Printers.PrinterId == pid);
    // apply your others conditions here
    ...
    query = query .Where(a => a.Users.UserName.Contains(keyword)).OrderBy(a => a.Users.UserName).ThenBy(a => a.Pc.PcName);
    // Return your new filtered list
    return query.ToList()
