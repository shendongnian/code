    [HttpPost]
    public ActionResult BudgetVSActualTabular(DateTime? startDate = null )
    { 
        if (startDate == null)
        {
            startDate  = new DateTime(2016, 06, 01);
        }
        //You should pass startDate.Value
        var Odata = _db.sp_BudgetedVsActualTabular(startDate.Value).ToList();
    }
