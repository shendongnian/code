    public ActionResult SomeAction(){
    ...
    try{
      ....
    }catch(Exception e){
      TempData["errorMessage"] = e.Message;
      return RedirectToAction("MaybeSomeOtherAction");
    }
    ...
    }
