    [HttpPost]
    public ActionResult ConfirmEmail(QuestionsViewModel model)
    {
       if(ModelState.IsValid)
       {
          //Do something here
       }
    
       return View(model);
    }
