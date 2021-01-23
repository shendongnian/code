    public ActionResult Action(int iCnt)
    {
        //get model based on 'iCnt'
        var model = GetModel(iCnt);  
        return PartialView("~/views/Folder/partialview.cshtml", model);
    }
