    message = db.GetLogs();
    
    int pageSize = 10;
    int pageNumber = (page ?? 1);
    var logs = message.OrderByDescending(i => i.timeStamp).ToPagedList(pageNumber, pageSize);
    
    foreach (var log in logs)
        log.Name = Customer.Where(a => a.Value == log.customerId.ToString()).FirstOrDefault().Text;
                    return PartialView("_LogPartialLayout", logs);
