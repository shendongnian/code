        public ActionResult GroupsDetailAjaxHandler(JQueryDataTableParamModel param, int? CompanyID)
        {
            var _table = _repo.GetData(CompanyID ?? 0);
            return Json(new
            {
                aaData = from emp in _table
                         select new[] {  emp.item1,emp.item3,emp.item3 }
            },
            JsonRequestBehavior.AllowGet);
        }
