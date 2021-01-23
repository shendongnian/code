    public async void openWindow()
    {
      TreeView tvURLs = await Network.CreatTVURLsAsync();
      StackPanel.Children.Add(tvURLs);
    }
    
    public async Task<TreeView> CreatTVURLsAsync()
    {
       //you are in dispatcher thread here, so you can access UI elements here
       TreeView TVURLs = new TreeView(); 
       TVURLs.Name = "URLs";
       TVURLs.Background = System.Windows.Media.Brushes.Transparent;
       TVURLs.BorderThickness = new Thickness(0);
    
    
       List<CPingables> lURLs = null;
       await Task.Run(() =>
       {
          //you are in new thread now, so you cannot access UI elements here
          lURL = ReadURLsFromFile();
       });
      
       //you are in dispatcher thread again, so you can access UI elements again
       foreach (CPingables item in lURLs)
       {
          var tviURL = new TreeViewItem();
          ..more stuff
          TVURLs.Items.Add(tviURL);
       }
    }
