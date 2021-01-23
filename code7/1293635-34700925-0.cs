    private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        MediaPlayer.Stop();
        string mediaPath = playlist.GetItemText(playlist.SelectedItem);
        MediaPlayer.Source = new Uri(mediaPath);
        MediaPlayer.Play();
    }
