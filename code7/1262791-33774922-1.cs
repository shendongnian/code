    public ActionResult Edit()
    {      
       EditGameVM receivedModel=TempData["Msg"] as EditGameVM;// Here you should cast your TempData to EditGameVM
       //to take data from TempData["Msg"], you should use receivedModel object
       string gameID=receivedModel.gameID;
       string gameName=receivedModel.gameName;
       return View(receivedModel);
    }
