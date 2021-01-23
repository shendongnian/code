    private async void insertTimer_Tick(object sender, EventArgs e)
    {
         if (onlineList.Items.Count > 0)
         {
             for (int i=0; i<onlineList.Items.Count; i++)
             {
                  // Creates a new Player with all the data it has
                  Players.Add(new Player 
                  { 
                        Name = playerName, 
                        Sex = playerSex, 
                        Vocation = playerVocation, 
                        Level = playerLevel, 
                        Achievements = playerAchievements, 
                        World = playerWorld, 
                        LastLogin = playerLastLogin, 
                        AccountStatus = playerAccountStatus, 
                        OnlineStatus = playerOnlineStatus 
                   };
              }
              
              // And now the inserts goes here
              .......
