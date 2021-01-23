    public ActionResult Details(int gid=19, int sid = 11)
    {
        var playerGameStats = from pgs in db.PlayerGameStats
                              join p in db.Players on pgs.Player_id equals p.id_player
                              where pgs.SeasonId == 11 && pgs.GameNumber == 19
                              select new TitansMVCWithBootStrap.Models.Player_Game_Stats
                              {
                                  PlayerName = p.PlayerName,
                                  PlateAppearance = pgs.PlateAppearance,
                                  Runs = pgs.Runs,
                                  Hits = pgs.Hits
                              };
        return View(playerGameStats);
    }
