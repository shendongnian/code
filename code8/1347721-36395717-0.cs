    [HttpPost]
    public ActionResult MyAction(MyModel model)
    {
        if (model.SomeCondition)
        {
            // return to the client the url to redirect to
            return Json(new { url = Url.Action("MyAction2") });
        }
        else
        {
            return PartialView("_MyPartialView");
        }
    }
    
