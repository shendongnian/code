    var query = from item in context.Invoices.AsNoTracking()
                where item.Repair.Job.Bodyshop.Manufacturer2Bodyshop.Any(m=>m.ManufacturerId==manufacturerId)
                && (item.InvoiceDate >= date12monthago && item.InvoiceDate <= today)
                && (item.InvType == "I" || item.InvType == null)
                select item;
    
    if (regionId.HasValue && regionId.Value > 0)
        query=query.Where(item=>item.Repair.Job.Bodyshop.Manufacturer2Bodyshop.Any(m=>m.RegionId==regionId.Value));
    
    if (vehicleTypeId.HasValue && vehicleTypeId.Value > 0)
        query=query.Where(item=>item.Repair.Job.Vehicle.Model.VehicleTypes.Any(v=>v.Id==vehicleTypeId.Value));
    
    var query2 = from item in query
                 group item by new { item.InvoiceDate.Month, item.Repair.Job.Bodyshop } into g
                 select new TReport
                 {
                     BodyshopId = g.Key.Bodyshop.Id,  
                     Month = g.Key.Month,
                     MonthAllJobTotal = g.Count()
                 };
    
    return query2.ToList();
