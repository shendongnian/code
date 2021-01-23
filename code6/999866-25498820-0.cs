    public ActionResult ReturnSpecialJsonIfInvalid(AwesomenessModel model)
    {
    if (ModelState.IsValid)
    {
        if(Request.IsAjaxRequest()
            return PartialView("NotEvil", model);
        return View(model)
    }
    if(Request.IsAjaxRequest())
    {
        return Json(new { error=true, message = RenderViewToString(PartialView("Evil",model)}));
    }
    return View(model);
}
