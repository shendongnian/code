    var query = db.Devices
                .Include(d => d.DeviceType)
                .Include(d => d.ManufacturerModel)
                .Include(d => d.ManufacturerModel.Manufacturer);
    
    string fromDate = "1/15/2016", toDate = "1/30/2016";
        DateTime fromDateTime, toDateTime;
    
    if(!DateTime.TryParse(fromDate, out fromDateTime))
    {
        // Make fromDateTime to Start of Day - 1/15/2016 12:00:00 AM
        fromDateTime = fromDateTime.Date;
        query = query.Where(x => x.Date >= fromDateTime);
    }
    
    if (!DateTime.TryParse(toDate, out toDateTime))
    {
        // Make toDateTime to End of day - 1/30/2016 11:59:59 PM
        toDateTime = toDateTime.Date.AddDays(1).AddTicks(-1);
        query = query.Where(x => x.Date <= toDateTime);
    }
    var result = query.ToList();
