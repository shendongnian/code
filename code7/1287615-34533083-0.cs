         public ActionResult ViewAllPlayers()
         {  
            //this should be from your database
            
            var teamviewer = new TeamViewModel();
            teamviewer.TeamName = "t1";
            teamviewer.Players = new List<Player>() { new Player { PlayerName = "p1" }, new Player { PlayerName = "p2" } };          
            return View();
         }
