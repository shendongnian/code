    public ActionResult Edit()
    {  
       //Here you should cast your TempData to EditGameVM:    
       EditGameVM receivedModel=TempData["Msg"] as EditGameVM;
       //To take data from TempData["Msg"], you should use receivedModel object:
       string gameID=receivedModel.gameID;
       string gameName=receivedModel.gameName;
       return View(receivedModel);
    }
