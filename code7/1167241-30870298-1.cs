    private void PlayMedia(object sender, RoutedEventArgs e)
    {
        MyMediaElement.Play();
    }
    
    private void PauseMedia(object sender, RoutedEventArgs e)
    {
        MyMediaElement.Pause();
        var currentTime = MyMediaElement.Position;
    
        MyTextBlock.Text = currentTime.ToString();
    }
