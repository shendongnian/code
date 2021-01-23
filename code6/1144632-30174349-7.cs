    private async void insertTimer_Tick(object sender, EventArgs e)
    {
         if (onlineList.Items.Count > 0)
         {
             for (int i=0; i<onlineList.Items.Count; i++)
             {
                  CurrentPlayer = onlineList.Items[i].ToString();
                  var playerProfile = await GetData();
                  foreach (var row in playerProfile)
                  {
                      .... gets player data ....
                  }
                  // Creates a new Player and add to the insertion list
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
