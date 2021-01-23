        public void EditPlayer(Common.Player alteredPlayer, Data.Game thisGame)
        {
            var playerData = Context.Players.Where(p => p.PlayerId == alteredPlayer.PlayerId).First();
            playerData.PlayerId = alteredPlayer.PlayerId;
            playerData.Goals = alteredPlayer.Goals
            /*etc... etc...*/
            playerData.Games = playerData.Games;
            playerData.Games.Add(thisGame);
            Context.SaveChanges();
        }
