        public JsonResult FetchP(string O)
        {
            List<SelectListItem> PList = new List<SelectListItem>();
             PList = _PService.GetAllPActive()
                      .Select(i => new SelectListItem()
                                 {
                                     Text = i.PName,
                                     Value = i.PID                                   
                                 }).ToList();
            return Json(PList, JsonRequestBehavior.AllowGet);
        }
    
