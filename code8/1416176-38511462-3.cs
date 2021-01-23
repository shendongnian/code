    public ActionResult BillDetails(int id)
    {
        var model = ReplaceYourModelForBillTotalAmountViewHere();
        return PartialView("Budgeting/_BillTotalAmount", model);
    } 
