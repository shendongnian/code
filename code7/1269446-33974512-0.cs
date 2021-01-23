            using (BettingLeagueEntities entities = new BettingLeagueEntities())
            {
                foreach (PlayerCheckBoxList p in this.PlayerList)
                {
                    PlayerLeague pl = new PlayerLeague();
                    pl.LID = ActiveLeague.ID;
                    pl.PID = p.ActivePlayer.ID;
                    entities.PlayerLeague.Add(pl);
                }                
                entities.SaveChanges();
            }
