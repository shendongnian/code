    using (var db = new ClothEntities())
    {
        var data = (from bterm in db.tbl_BillingTerm
             select new
             {
                 bterm.BTId,
                 BillingTerm =
                     bterm.BTTitle + " " + 
                     SqlFunctions.StringConvert(bterm.BTBill) 
                     + ": USD/month")
             });
    }
