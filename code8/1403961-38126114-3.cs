     public StatsSeasonViewModel(IGrouping<int,Stat> playerStats)
     {
         player_id = playerStats.Key;
         games_played = playerStats.Count();
         total_wickets = playerStats.Sum(st=>st.wickets);
         // ....
     }
    
