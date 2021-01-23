    if (index != System.Windows.Forms.ListBox.NoMatches)
    {
    	string username = TextBoxConnectedClients.SelectedItem.ToString();
    
    	// Check if form is already opened. Username will be unique.
    	var form = b.firstOrDefault(f => f.Username == username);
    	if (form == null)  // Show new form
    	{
    		TalkForm a = new TalkForm(im, username, displayname);
    		b.Add(a);
    		a.Show();
    	}
    	else // Activate already opened form
    	{
    		form.BringToFront();
    	}
    }
