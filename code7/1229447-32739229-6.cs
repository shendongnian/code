	private static string computeCondition(string current, string newCondition)
	{
		if (!string.IsNullOrEmpty(current))
		{
			current += " AND ";
		}
		return current + newCondition;
	}
	private void BTN_advancedSearch_Click(object sender, EventArgs e)
	{
		// Creates the variable part of the custom query
		string customwhereclause = "";
		if (CHK_enableGameName.Checked == true)
		{
			Connectqry(customwhereclause);
			
			customwhereclause = computeCondition(customwhereclause, "Game.GameName LIKE '%" + TXT_addGame.Text + "%'");
		}
		...
