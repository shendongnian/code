    private void BTN_advancedSearch_Click(object sender, EventArgs e)
    {
        // Creates the variable part of the custom query
        List<string> whereClausesList = new List<string>();
		
		if (CHK_enableGameName.Checked == true)
		{
			Connectqry(customwhereclause);
			whereClausesList.Add("Game.GameName LIKE '%" + TXT_addGame.Text + "%'");
		}
		...
		string.Join(" AND ", whereClausesList);
