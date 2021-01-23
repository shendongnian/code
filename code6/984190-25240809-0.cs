    void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            try
            {
                DataModel.YoutubeVideo value = e.NavigationParameter as DataModel.YoutubeVideo;
                if(!string.IsNullOrWhiteSpace(value.id))
                {
                    txttitle.Text = value.title;
                    Mediaplayer.Source = value.youtubelink;
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
           
        }
