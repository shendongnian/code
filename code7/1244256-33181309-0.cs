    // Add the player
    EnteredPlayers.Add(player);
    // Get the position
    int position = EnteredPlayer.Count
    // Create a dictionary with the position names
    // Put this dictionary outside of your method managing the games
    Dictionary<string, string> positionNames = new Dictionary<string, string>(){
        { "1", "First" },
        { "2", "Second" },
        { "3", "Third" }
    };
    // Assign the label text
    finishText.Text = positionNames[position.ToString()]; 
