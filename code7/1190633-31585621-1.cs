    var teamsFinal = from p in pit
                     join pd in playerDetail on p.PlayerID equals pd.PlayerID 
                     where pd.IsArchived == false
                     group new {p,pd} by  new 
                                         { 
                                            pd.PlayerID ,
                                            pd.ForeName, 
                                            pd.SurName
                                         } into g
                     select new PlayersViewModel
                     {
                         TeamID = g.Select(x => x.p.TeamID).ToList(), 
                         PlayerID = g.Key.PlayerID, 
                         PlayerName = g.Key.ForeName + " " + g.Key.SurName
                     };
