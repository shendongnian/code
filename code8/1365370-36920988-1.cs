    if (index != System.Windows.Forms.ListBox.NoMatches)
    {
    	string username = TextBoxConnectedClients.SelectedItem.ToString();
    
    	// Check if form is already opened. Username will be unique.
    	if (b.Count(f => f.Username == username) > 0) 
    	{
    		TalkForm a = new TalkForm(im, username, displayname);
    		b.Add(a);
    		a.Show();
    	}
    }
