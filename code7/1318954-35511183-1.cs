    public ActionResult AddPlayersView(int id)
    {
        var GameSelected = db.Games.Find(id);
        if (GameSelected== null)
        {
            return HttpNotFound();
        }
        var np = new AddPlayersToGame { GameID = id, GameTitle =  GameSelected.GameTitle };
        
        var playerList = db.Players.Select(m => new
        {
            PlayerUserName = m.PlayerUserName,
            PlayerId = m.PlayerId
        }).ToList();
        
        np.Players = new MultiSelectList(playerList, "PlayerIDs", "PlayerUserName");
        return View(np);
    }
    [HttpPost]
    public ActionResult AddPlayersView(AddPlayersToGame model)
    {
        foreach (var playerID in model.PlayerIDs)
        {
            var SelPlayer = db.Players.Find(playerID);
            if (SelPlayer== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (SelPlayer != null)
            {
                Game GameSelected = new Game();
                GameSelected.GamePlayers.Add(SelPlayer);
                db.Entry(GameSelected).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        return RedirectToAction("GameDetailsView");
    }
