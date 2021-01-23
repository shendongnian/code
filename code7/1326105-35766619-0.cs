    var ptrNotInList = ptrInList.Select(t => t.Printers.PrinterName)
              .Except(data.Select(e => e.Printer))
              .ToList();
     
    if (ptrNotInList != null)
    {
        foreach (var m in ptrNotInList)
        {
            AuditPrinters printerToDelete = (from t in context.AuditPrinters where t.Printers.PrinterName == m && t.PcId==pcInDb && t.UserId==userInDb select t).SingleOrDefault();
            context.AuditPrinters.Remove(printerToDelete);
        }
    }
    context.SaveChanges();
