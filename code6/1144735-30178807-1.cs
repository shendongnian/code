    public PublicPortalController(..., IViewHelper helper)
    {
        _helper = helper;
    }
    
    ....
    
    public JsonResult GetPublicInformation(PublicPortalViewModel model, bool captchaValid)
    {
        ....
                //fill model data using by calling the service
                model = _service.GetPublicPortalData(model);
                var content = _helper.SerializeView(ControllerContext, ViewData, TempData, "DisplayPublicInformation", model);
                return Json(new { success = true, htmlContent = content });
       ....
    }
