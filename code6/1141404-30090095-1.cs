    [HttpPost]
    public ActionResult UpdateChart(DateTime startDate, DateTime endDate)
    {
      // Pass the dates to the partial view
      ViewBag.StartDate = startDate;
      ViewBag.EndDate = endDate;
      return PartialView("_Chart"); // rename to suit
    }
