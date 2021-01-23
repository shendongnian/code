    public Youtube()
    {
         InitializeComponent();
         Loaded += Youtube_Loaded;
    }
    
    async void Youtube_Loaded(object sender, RoutedEventArgs e)
    {
         try
         {
             string videoId = "iqjMRdev0FI";
             var url = await YouTube.GetVideoUriAsync(videoId, YouTubeQuality.Quality480P);
             player.Source = url.Uri;
         }
         catch (Exception ex)
         {
             System.Diagnostics.Debug.WriteLine(ex.Message);
         }
            
    }
