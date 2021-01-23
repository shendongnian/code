    public ActionResult BillDetails(int id,int budgetId)
    {
        var model = ReplaceYourModelForBillTotalAmountViewHere();
        return PartialView("Budgeting/_BillTotalAmount", model);
    } 
