    var leagueTable_Object =
        JsonConvert.DeserializeObject<LeagueTable.RootObject>(responseText);
    DataGridTextColumn name = new DataGridTextColumn();
    name.Binding = new Binding("name");
    League_DataGrid.Columns.Add(name);
    DataGridTextColumn points = new DataGridTextColumn();
    points.Binding = new Binding("points");
    League_DataGrid.Columns.Add(points);
    DataGridTextColumn playedGames = new DataGridTextColumn();
    playedGames.Binding = new Binding("playedGames");
    League_DataGrid.Columns.Add(playedGames);
    DataGridTextColumn goals = new DataGridTextColumn();
    goals.Binding = new Binding("goals");
    League_DataGrid.Columns.Add(goals);
    DataGridTextColumn goalsAgainst = new DataGridTextColumn();
    goalsAgainst.Binding = new Binding("goalsAgainst");
    League_DataGrid.Columns.Add(goalsAgainst);
    DataGridTextColumn goalsDifference = new DataGridTextColumn();
    goalsDifference.Binding = new Binding("goalsDifference");
    League_DataGrid.Columns.Add(goalsDifference);
    foreach (var classifica in leagueTable_Object.standing)
    {
        League_DataGrid.Items.Add(new LeagueTable.Classifica
        {
            name = classifica.position + " " + classifica.teamName,
            points = classifica.points,
            playedGames = classifica.playedGames,
            goals = classifica.goals,
            goalsAgainst = classifica.goalsAgainst,
            goalsDifference = classifica.goalDifference
        });
    }
