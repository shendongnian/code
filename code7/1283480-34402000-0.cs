    [HttpPost]
    public ActionResult SearchClient(ClientInfo client)
    {
        Repo repo = new Repo();
        var search = client.clientName; // Just want to get the client name
        return Json(new
        {
            list = repo.SearchClient(search),
            //count = result.Count
        }, JsonRequestBehavior.AllowGet);
    }
