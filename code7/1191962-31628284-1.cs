    private void cmdLogin_Click(object sender, EventArgs e)
    {
    	// Add example logins
    	lstConsoleOutput.Items.Add("Adam[1.1.1.1] logged into the server");
    	lstConsoleOutput.Items.Add("Barry[227.127.27.2] logged into the server");
    	lstConsoleOutput.Items.Add("Matt[192.172.152.132] logged into the server");
    	lstConsoleOutput.Items.Add("Some Random Long Screen Name 123435!#$!@#$[255.255.0.100] logged into the server");
    
    	AnalyzeConsoleOutput(lstConsoleOutput, lstOnlinePlayers);
    }
    
    private void cmdLogout_Click(object sender, EventArgs e)
    {
    	// Add example logouts
    	lstConsoleOutput.Items.Add("Matt left the game");
    	lstConsoleOutput.Items.Add("Barry left the game");
    	lstConsoleOutput.Items.Add("Some Random Long Screen Name 123435!#$!@#$ left the game");
    
    	AnalyzeConsoleOutput(lstConsoleOutput, lstOnlinePlayers);
    }
    
    private void AnalyzeConsoleOutput(ListBox listboxToAnalyze, ListBox onlinePlayersListbox)
    {
    	const string LoginIdentifier = "] logged into the server";
    	const string LogoutIdentifer = " left the game";
    	string playerName;
    
    	foreach (var item in listboxToAnalyze.Items)
    	{
    		// Check if a player has logged in and add them to the players list box
    		if (item.ToString().Contains(LoginIdentifier))
    		{
    			playerName = item.ToString().Substring(0, item.ToString().IndexOf('['));
    
    			if (!onlinePlayersListbox.Items.Contains(playerName))
    			{
    				onlinePlayersListbox.Items.Add(playerName);
    			}
    		}
    
    		// Check if a player has logged out and remove them from the players list box
    		if (item.ToString().Contains(LogoutIdentifer))
    		{
    			playerName = item.ToString().Substring(0, item.ToString().IndexOf(LogoutIdentifer, 0));
    
    			if (onlinePlayersListbox.Items.Contains(playerName))
    			{
    				onlinePlayersListbox.Items.Remove(playerName);
    			}
    		}
    	}
    }
