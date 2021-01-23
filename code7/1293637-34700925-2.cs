    private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        MediaPlayer.Stop();
        string mediaPath = ((ListBoxItem)playlist.SelectedItem).Content.ToString();
        MediaPlayer.Source = new Uri(mediaPath);
        MediaPlayer.Play();
    }
