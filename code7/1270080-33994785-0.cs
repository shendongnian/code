    using (BettingLeagueEntities entities = new BettingLeagueEntities())
    {
    foreach (PlayerCheckBoxList p in this.PlayerList)
    {
    // Check if the Player is seleceted and if the ActivePlayer has the Active League
    if (p.IsSelected == true && p.ActivePlayer.PlayerLeague.All(x => x.LID != this.ActiveLeague.LID))
    {
    // Define the new PlayerLeague
    PlayerLeague pl = new PlayerLeague {PID = p.ActivePlayer.PID, LID = this.ActiveLeague.LID};
    var localPlayer = entities.Set<Player>().Local.FirstOrDefault(x => x.PID == p.ActivePlayer.PID);
     if (localPlayer != null)
     {
          entities.Entry(localPlayer).State = System.Data.Entity.EntityState.Detached;
     }
     if (entities.Entry(p.ActivePlayer).State == System.Data.Entity.EntityState.Detached)
     {
          entities.Player.Add(p.ActivePlayer);
          entities.Entry(p.ActivePlayer).State = System.Data.Entity.EntityState.Modified;
     }
     var localLeague = entities.Set<League>().Local.FirstOrDefault(x => x.LID == this.ActiveLeague.LID);
     if (localLeague != null)
     {
          entities.Entry(localLeague).State = System.Data.Entity.EntityState.Detached;
     }
     if (entities.Entry(this.ActiveLeague).State == System.Data.Entity.EntityState.Detached)
     {
          entities.League.Add(this.ActiveLeague);
          entities.Entry(this.ActiveLeague).State = System.Data.Entity.EntityState.Modified;
     }
     p.ActivePlayer.PlayerLeague.Add(pl);
     this.ActiveLeague.PlayerLeague.Add(pl);
     }
    else
    {
       // Check if there is a PlayerLeague for this Player and league
       bool hasPlayerLeague =
                            entities.PlayerLeague.Any(x => x.LID == this.ActiveLeague.LID && x.PID == p.ActivePlayer.PID);
        if (hasPlayerLeague && p.IsSelected == false)
        {
              // Find PlayerLeague
              PlayerLeague pl =
                        entities.PlayerLeague.FirstOrDefault(
                        x => x.LID == this.ActiveLeague.LID && x.PID == p.ActivePlayer.PID);
               // Attach and Remove PlayerLeague
               entities.PlayerLeague.Attach(pl);
               entities.PlayerLeague.Remove(pl);
         }
                            
        entities.SaveChanges();
    }
