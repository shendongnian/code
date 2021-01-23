    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public JsonResultRegisterPartial(RegisterModel model)
    {
        if (ModelState.IsValid)
        {      
            //do stuff
             return Json(new {Success=true });
        }
        return Json(new {Success=false});
    }
