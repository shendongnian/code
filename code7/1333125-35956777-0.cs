            [HttpGet]
            public ActionResult Index(School model)
            {
                var schooList = schGateway.SelectAll();
                model.SchooList = schooList;
    
                return Json(model, JsonRequestBehavior.AllowGet);
            }
