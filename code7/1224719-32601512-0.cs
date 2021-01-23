    from i in db.item
    group i by new{
      type = i.Type,
     eDate = i.Expiry_date
    } into grp 
    select new
    {
     type = grp.key.Type,
     date =  grp.key.Expiry.Date.Subtract(DateTime.Now.Date).Days
    }
