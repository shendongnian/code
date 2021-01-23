	if(HomeTeamListBox.Items.Count > 5)
	{
		var lastIndex = HomeTeamListBox.Items.Count - 5; 
		for(int i=0; i < lastIndex; i++)
		{
		   HomeTeamListBox.Items.RemoveAt(i);
		}
	}
