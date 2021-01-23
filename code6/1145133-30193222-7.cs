    //Replace this with wherever you pull the info from (as a Player entity)
    var currentPlayersData = new List<Player>();
    
    using(var ctx = new RookstayersDbContext())
    {
        //Iterate through your new data collection
        foreach(var player in currentPlayersData)
        {
            var dbPlayer = ctx.Players.FirstOrDefault(x => x.Name == player.Name);
    
            //Insert new player if not existing
            if(dbPlayer == null)
            {
                player.IsOnline = true; //ensure flagged as online
                ctx.Players.Add(player); //add new player
                continue; //proceed through to next current player
            }
    
            //If player already exists, flag as online
            dbPlayer.IsOnline = true;
        }
    
        //Now iterate through your database collection
        foreach(var player in ctx.Players)
        {
            //If no player information found in current players data, flag as offline
            if (!currentPlayersData.Any(x => x.Name == player.Name))
                player.IsOnline = false; //flag player as offline
        }
    
        //Save any changes made in this context to database
        ctx.SaveChanges();
    }
