    public JsonResult GetThis(string typ1)
    {     
        using(ThisContext tpc = new ThisContext())
        {
            IQueryable<ThisDB> oDataQuery = tpc.ThisDBs;
            if (!string.IsNullOrWhiteSpace(typ1))
            {
                oDataQuery = oDataQuery.Where(a => a.Type == typ1);
                var result = oDataQuery.ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else return null;
        }
    }
