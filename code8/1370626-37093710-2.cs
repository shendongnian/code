    DataTable games = new DataTable()
    games.Columns.Add("Home_Team_ID", typeof(int));
    games.Columns.Add("Home_Team_Name", typeof(string));
    games.Columns.Add("Away_Team_ID", typeof(int));
    games.Columns.Add("Away_Team_Name", typeof(string));
    games.Columns.Add("Home_Team_Score", typeof(int));
    games.Columns.Add("Away_Team_Score", typeof(int));
    games.Columns.Add("Game_Date", typeof(DateTime));
    
    var results = from dataRows1 in MatchStatistics.AsEnumerable()
                  join dataRows2 in Teams.AsEnumerable()
                  on dataRows1.Field<int>("Home_Team_ID") equals dataRows2.Field<int>("Team_ID") 
                  join dataRows3 in Teams.AsEnumerable()
                  on dataRows1.Field<int>("Away_Team_ID") equals dataRows3.Field<int("Team_ID")
                  select games.LoadDataRow(new object[]
                  {
                      dataRows1.Field<int>("Home_Team_ID"),
                      dataRows2.Field<string>("Team_Name"),
                      dataRows1.Field<int>("Away_Team_ID"),
                      dataRows3.Field<string>("Team_Name"),
                      dataRows1.Field<int>("Home_Team_Score"),
                      dataRows1.Field<int>("Away_Team_Score"),
                      dataRows1.Field<DateTime>("Game_Date")
                  }, false);
