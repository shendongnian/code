    private void GotoAddress_Click(object sender, RoutedEventArgs e)
    {
    	///Check if the URL or Address bar is blank
    	if(TxtWebAdd.Text != "")
    	{
    		Uri uriResult;
    		///if not then checking if the URL is valid 
    		if(Uri.TryCreate(TxtWebAdd.Text, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
    			wb1.Navigate(TxtWebAdd.Text);
    		else
    			MessageBox.Show("This is not a valid URL please check");
    	}
    	else
    	{
    		///this is how it will navigate to blank page when WebAddress TextBox is blank.
    		wb1.Navigate("about:blank");
    	}
    }
