    private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        MediaPlayer.Stop();
        MediaPlayer.Source = new Uri(safePlayList[playlist.SelectedIndex]);
        MediaPlayer.Play();
    }
