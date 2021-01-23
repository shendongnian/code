    public IQueryable<Report> GetReport(CmsEntities context, long? manufacturerId, long? regionId, long? vehicleTypeId)
        {
    {
            var now = DateTime.Now;
            var today = new DateTime(now.Year, now.Month, 1);
            var date1monthago = today.AddMonths(-1);
            var date2monthago = today.AddMonths(-2);
            var date3monthago = today.AddMonths(-3);
            var date4monthago = today.AddMonths(-4);
            var date5monthago = today.AddMonths(-5);
            var date6monthago = today.AddMonths(-6);
            today = TimeManager.EndOfDay(new DateTime(now.AddMonths(-1).Year, today.AddMonths(-1).Month, DateTime.DaysInMonth(now.Year, today.AddMonths(-1).Month)));             
        var query = from item in context.Invoices.AsNoTracking()
                    where (item.InvoiceDate >= date12monthago && item.InvoiceDate <= today)
                    && (item.InvType == "I" || item.InvType == null)
                    select item;
    
        if (manufacturerId.HasValue && manufacturerId.Value > 0)
            query=query.Where(item=>item.Repair.Job.Bodyshop.Manufacturer2Bodyshop.Any(m=>m.ManufacturerId==manufacturerId));
    
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
        
        return query2;
    }
