    [Authorize()]
    public async Task<ActionResult> Search(string query)
    {
       WinesApiController winesCtrl = new WinesApiController();
       var listOfWines = await winesCtrl.Get(query);
       return PartialView("_WineResult", listOfWines);
    }
