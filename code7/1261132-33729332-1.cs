    private void btnConnect_Click(object sender, RoutedEventArgs e)
    {
         var dataContext = btnConnect.DataContext as <<Your Model>>;
    	 dataContext.IsProcessed = true;
    }
