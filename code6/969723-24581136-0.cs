    public BitmapImage iconStop = new BitmapImage();
    public BitmapImage iconPause = new BitmapImage();
    public BitmapImage iconPlay = new BitmapImage();
    private void PlayButton_OnClick(object sender, RoutedEventArgs e)
    {
        switch (medState)
        {
            case mediaState.Playing:
                medState = mediaState.Paused;
                //  mediaE.Pause();
                playButton.Content = " Play";
                var sri = Application.GetResourceStream(new Uri("Assets/download(1).jpg", UriKind.Relative));
                iconStop.SetSource(sri.Stream);
                ControlImg.Source = iconStop;
                break;
            case mediaState.Paused:
                medState = mediaState.Stopped;
                //  mediaE.Play();
                playButton.Content = " Pause";
                var sri1 = Application.GetResourceStream(new Uri("Assets/download(2).jpg", UriKind.Relative));
                iconPlay.SetSource(sri1.Stream);
                ControlImg.Source = iconPlay;
                break;
            case mediaState.Stopped:
                medState = mediaState.Playing;
                // mediaE.Play();
                playButton.Content = " stopped";
                var sri2 = Application.GetResourceStream(new Uri("Assets/download(1).jpg", UriKind.Relative));
                iconStop.SetSource(sri2.Stream);
                ControlImg.Source = iconStop;
                break;
            default:
                break;
        }
