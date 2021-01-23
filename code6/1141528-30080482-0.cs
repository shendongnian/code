    if(ModelState.IsValid)
    {
     // ...........
    }
    if (Request.IsAjaxRequest())
    {
    return new JsonResult { Data = new { success = true, message = message2 } };
    }
    
    TempData["Message"] = message2;    
    return View(model);
