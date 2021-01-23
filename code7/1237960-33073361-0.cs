     public JsonResult getModulesByFranchisorID(string FranchisorId)
        {
            var FranchisorModules = (from a in db.MapModuleFranchisors
                                     where a.FranchsiorId == FranchisorId && a.ModuleFlag == 1
                                     select new
                                     {
                                         a.ModuleId,
                                     }).AsEnumerable();
            return Json(FranchisorModules, JsonRequestBehavior.AllowGet);
        }
