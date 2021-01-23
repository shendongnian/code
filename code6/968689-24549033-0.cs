    public JsonResult SelectProblems(int id)
    {
        db.Configuration.ProxyCreationEnabled = false;
        IEnumerable<Problem> Problems = db.Problems.Where(p => p.TypeOfProblemID == id);
        return Json(Problems,JsonRequestBehavior.AllowGet);
    }
