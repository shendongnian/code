    IEnumerable<MyRecord> query = GetRecord("EquipRequest");
    if (!status.Equals(""))
    {
        if (deliveryDateFrom.HasValue) 
            query = query.Where(x => x.DeliveryDate >= deliveryDateFrom);
        if (deliveryDateTo.HasValue) 
            query = query.Where(x => x.DeliveryDate <= deliveryDateTo);
    }
    IEnumerable<MyRecord> result = query.ToList();
