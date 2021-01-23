    [HttpPost]
     public ActionResult List(string p)
        {
           ViewBag.name = p;
           return Json(ViewBag);
        }
