    foreach (var item in leaderDetail)
	{
        //Create a new label for the Email
        var VpEmail = new Label { Text = item.Email, FontSize = 14, HorizontalOptions = LayoutOptions.Center };
	    vpDetails.Children.Add(new Label { Text = item.Name ,FontSize=14, HorizontalOptions = LayoutOptions.Center});
	    vpDetails.Children.Add(VpEmail);
        var tgrVPEmail = new TapGestureRecognizer();
		tgrVPEmail.Tapped += (s, e) => Device.OpenUri(new Uri("mailto:" + item.Email));
		VpEmail.GestureRecognizers.Add(tgrVPEmail); 
    }
