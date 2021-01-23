      private async Task PlayAudio(Uri sourceUri, ListViewItem soundItem)
        {
            MediaElement player = RequestPlayer(soundItem);
            player.IsLooping = true;
            player.AutoPlay = false;
            player.MediaOpened += Player_MediaOpened;
            player.MediaFailed += Player_MediaFailed;
            player.Source = sourceUri;
            player.IsLooping = true;
            //Add media element to xaml tree if not added by your RequestPlayer Method..
            this.LayoutRoot.Children.Add(player);
        }
        private void Player_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            
        }
        private async void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            await player.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                player.Play();
            });
        }
