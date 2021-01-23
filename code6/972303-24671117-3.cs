    using (var db = new ClothEntities())
    {
        var data = (from bterm in db.tbl_BillingTerm
             select new
             {
                 bterm.BTId,
                 BillingTerm = string.Format(
                     "{0} {1}: USD/month",
                     bterm.BTTitle,
                     SqlFunctions.StringConvert(bterm.BTBill))
             });
    }
