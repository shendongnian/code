    [HttpGet]
    public ActionResult GetAllFacts()
    {
        try
        {
            using (var context = new DbDemo())
            {
                var allData_Facts = context.Objblog.Take(2).ToList();
                return Json(new { success = true, alldata = allData_Facts }, JsonRequestBehavior.AllowGet);
            }
        }
        catch (Exception e)
        {
            return Json(new { success = false, ex = e.Message }, JsonRequestBehavior.AllowGet);
        }
        
    }
