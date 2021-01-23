    [HttpPost]
    public PartialViewResult AddLotFields(int numberOfFields)
    {
        var lots = new List<LotViewModel>();
        for (int index = 0; index < numberOfFields; index++)
        {
            lots.Add(new LotViewModel());
        }
    
        return PartialView("~/Areas/Admin/Views/MainController/_LotForm.cshtml", lots);
    }
