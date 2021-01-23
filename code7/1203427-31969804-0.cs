    private void SaveNewPlayers(Common.Game newGame, Data.Game dataGame)
    {
        foreach (var player in newGame.Players)
        {
            var isNewPlayer = player.PlayerId < 1; 
            var playerData = MapToData(player);
            if (isNewPlayer)
            {
                Context.Players.Add(playerData);
                dataGame.Players.Add(playerData);
                Context.SaveChanges();
            }
            else
            {
                EditPlayer(player, dataGame);
            }
        }
    }
