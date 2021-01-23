    public ActionResult List()
    {
       var model= _repository.Items.ToViewModel();
       
       if (Request.IsAjaxRequest())
       {
           return Json(model, JsonRequestBehavior.AllowGet);
       }
       if (ControllerContext.IsChildAction)
       {
           return PartialView("_ListPartial", model);
       }
       return View(model);
    }
