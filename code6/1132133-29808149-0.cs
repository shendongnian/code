    bool TeamPlayers(string teamName, ComboBox team)//Makes the players of the selected team available for selection as scorers
    {
        Dictionary<string, string[]> teamNames = new Dictionary<string, string[]>();
        teamNames.Add("Canada", new string[] { "Johny Moonlight", "DTH Van Der Merwe", "Phil Mackenzie" });
        teamNames.Add("New Zealand", new string[] { "Dan Carter", "Richie Mccaw", "Julian Savea" });
        teamNames.Add("South Africa", new string[] { "Jean de Villiers", "Bryan Habana", "Morne Steyn" });
        
        team.DataSource = teamNames[teamName];
        return (true);
    }
