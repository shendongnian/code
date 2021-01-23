    private async void addCharacter_Click(object sender, EventArgs e)
    {
        playername = Interaction.InputBox("Please enter a character name.", "Input Character Name");
        if (playername.Length > 0)
        {
            //get the player data from the website
            //name, vocation and level
            //add their values to the 3 variables: charname, voc and lvl.
            //and add them to the listview (characterList)
           
                var players = await GetPlayers();
                foreach (var row in players)
                {
                    if (row[0] == "Name:")
                    {
                        charname = row[1];
                    }
                }
    .
    . 
    .
