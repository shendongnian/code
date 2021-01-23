                using (BettingLeagueEntities entities = new BettingLeagueEntities())
                {
                    foreach (PlayerCheckBoxList p in this.PlayerList)
                    {
                        PlayerLeague pl = new PlayerLeague();
                        pl.LID = ActiveLeague.ID;
                        pl.PID = p.ActivePlayer.ID;
                        entities.PlayerLeague.Add(pl);
                    }                
                    string saveString = ApplicationHelper.Save(entities);
                     // the saveString would make its way to 
                     //    the front-end to be show to the user.
                }
