    public ActionResult ListReports(int? page)
    {
        var pageNumber = page ?? 1;     
        var listOfReports = db.PublicReport.OrderByDescending(d => d.CreatedDate).Where(c => c.CategoryId == 1).ToList();
         var pagedList = listOfReports.ToPagedList(pageNumber, 3); // modify
         return View("ReportList", pagedList ); // modify
     }
