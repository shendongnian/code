    public ActionResult GetStudies(int pageSize = 10, int pageNum = 1)
    {
        var studies = GetStudiesData().ToList();
        var studiesCount = studies.Count();
        var studiesPaged = studies.OrderBy(s=>s.PatientID).Skip(pageSize*pageNum).Take(pageSize);
                
        var result = new { TotalRows = studiesCount, Rows = studiesPaged };
                
        //this line gives error
        //There is already an open DataReader associated with this Command which must be closed first.
        var data = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.None,
        new Newtonsoft.Json.JsonSerializerSettings()
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        });
                
        return Json(data, JsonRequestBehavior.AllowGet);
    }
