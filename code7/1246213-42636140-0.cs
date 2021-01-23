    public ActionResult SomeMethod(string ReportType, DateTime? FromDate, DateTime? ToDate)
    {
        var query = UnitOfWork.RepoTestResAnalysis.GetAll();
        var QueryData = query.Where(x => x.DateField >= (FromDate ?? x.DateField) && x.DateField <= (ToDate ?? x.DateField).ToList();                 
    }
