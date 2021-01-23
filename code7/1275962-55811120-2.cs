    public jsonresult addDetail(customer records)
    {
        var db = new StorageContext();
        db.customer.Add(records);
        db.SaveChanges();
        foreach (var item in records.detaile)
        {
            db.customerdetail.Add(item);
            db.SaveChanges();
        }
    }
