    public ActionResult BudgetVSActualTabular(DateTime startDate = default(DateTime))
    {
        if(startDate == DateTime.MinValue)
            startDate = new DateTime(2014,6,1);
        // After the check for a missing parameter pass the startDate as before
        var Odata = _db.sp_BudgetedVsActualTabular(startDate).ToList();
        .....
    }
