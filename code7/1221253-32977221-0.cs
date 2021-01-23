    var query = context.Invoices.AsNoTracking().Where(item =>
    	(item.InvType == "I" || item.InvType == null) &&
    	(item.InvoiceDate >= date12monthago && item.InvoiceDate <= today));
    
    if (regionId.HasValue && regionId.Value > 0)
    	query = query.Where(item =>
    		item.Repair.Job.Bodyshop.Manufacturer2Bodyshop.Any(source =>
    			source.ManufacturerId == manufacturerId && source.RegionId == regionId.Value));
    else
    	query = query.Where(item => 
    		item.Repair.Job.Bodyshop.Manufacturer2Bodyshop.Any(source => 
    			source.ManufacturerId == manufacturerId));
    
    if (vehicleTypeId.HasValue && vehicleTypeId.Value > 0)
    	query = query.Where(item =>
    		item.Repair.Job.Vehicle.Model.VehicleTypes.Any(vehicleType => 
    			vehicleType.Id == vehicleTypeId.Value);
    
    var query2 = query
    	.GroupBy(item => new { Month = item.InvoiceDate.Month, BodyshopId = item.Repair.Job.Bodyshop.Id })
    	.Select(g => new TReport { BodyshopId = g.Key.BodyshopId, Month = g.Key.Month, MonthAllJobTotal = g.Count() });
    
    var result = query2.ToList();
