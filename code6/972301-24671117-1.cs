    using (var db = new ClothEntities())
    {
        var raw = (from bterm in db.tbl_BillingTerm
                    select new
                    {
                        bterm.BTId,
                        bterm.BTTitle,
                        bterm.BTBill
                    }).ToList();
        var data = raw.Select(bterm => new
            {
                bterm.BTId,
                BillingTerm = string.Format(
                    "{0} {1}: USD/month",
                    bterm.BTTitle,
                    bterm.BTBill)
            });
    }
