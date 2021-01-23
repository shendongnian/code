    public ActionResult ProjectNumberResultView(string searchString)
    {
        ViewBag.InputSearchString = searchString;
        IEnumerable<ProjectNumberSearchResult> results = new List<ProjectNumberSearchResult>();
    
        if (!String.IsNullOrEmpty(searchString))
        {
            searchString= searchString.Trim();
    
            results = (from p in db.T_ProjectNumber
                       from unit in db.T_Unit
                      .Where(unit => unit.ProjectNumber == p.ProjectNumber)
                      .DefaultIfEmpty()
    
                       where p.ProjectNumber.Contains(searchString)
    
                       select new ProjectNumberSearchResult
                       {
                           ProjectNumber = p.ProjectNumber,
                           UnitId = unit.UnitId,
                           IpAddress = unit.IpAddress
                       }
            );
        }
        return View(results);
    }
