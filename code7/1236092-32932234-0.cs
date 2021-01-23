    private void Song_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        Song song = (sender as Grid).DataContext as Song;
        // Show PopupMenu
        // ...
    }
