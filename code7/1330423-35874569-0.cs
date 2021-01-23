    private void VideoControl_MediaEnded(object sender, RoutedEventArgs e)
    {
        // choose the next media file 
        ...
        //make the following explicitly
        MediaPlayer.Stop();      
        MediaPlayer.Source = null;
        model.OnPropertyChanged("MySource");
        MediaPlayer.Play();
    }
