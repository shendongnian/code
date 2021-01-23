    <RadioButton x:Name="rdobtn_AlwaysTop" Content="Always top" HorizontalAlignment="Left" Margin="10,258,0,0" VerticalAlignment="Top" GroupName="WindowZIndex" Checked="SetWindowZIndex"/>
    <RadioButton x:Name="rdobtn_TopWhilePlaying" Content="Top while playing" HorizontalAlignment="Left" Margin="96,258,0,0" VerticalAlignment="Top" GroupName="WindowZIndex" Checked="SetWindowZIndex"/>
    <RadioButton x:Name="rdobtn_LetUserPick" Content="Who cares" HorizontalAlignment="Left" Margin="219,258,0,0" VerticalAlignment="Top" GroupName="WindowZIndex" IsChecked="True" Checked="SetWindowZIndex" />
        public static bool IsMediaPlaying = false;//something to keep track of the player state
        private void play_Click(object sender, RoutedEventArgs e)
        {
            PlayMedia();
        }
        public void PlayMedia()
        {
            if (IsMediaPlaying == false)
            {
                //nothing is playing
                if (mePlayer.Source == new Uri(playlist[listbox4.SelectedIndex].Filepath, UriKind.RelativeOrAbsolute))
                {
                    //nothing is playing, but the player already has the correct file loaded
                    mePlayer.LoadedBehavior = MediaState.Play;//play it
                }
                else
                {
                    //nothing is playing and the media player's loaded file(if any) is different than the selected file so play the selected file
                    mePlayer.Source = new Uri(playlist[listbox4.SelectedIndex].Filepath, UriKind.RelativeOrAbsolute);
                    mePlayer.LoadedBehavior = MediaState.Play;
                }
            }
            else//something is already playing
            {
                if (mePlayer.Source == new Uri(playlist[listbox4.SelectedIndex].Filepath, UriKind.RelativeOrAbsolute))
                {
                    //the proper file is already playing
                }
                else
                {
                    //something is playing but it looks like the user wants to play something different
                    mePlayer.Source = new Uri(playlist[listbox4.SelectedIndex].Filepath, UriKind.RelativeOrAbsolute);
                    mePlayer.LoadedBehavior = MediaState.Play;
                }
            }
            IsMediaPlaying = true;
            SetWindowZIndex();
        }
        private void SetWindowZIndex(object sender, RoutedEventArgs e)
        {
            SetWindowZIndex();
        }
        private void SetWindowZIndex()
        {
            if (rdobtn_AlwaysTop.IsChecked == true)
            {
                Window parent = Window.GetWindow(this);
                parent.Topmost = true;
            }
            else if (rdobtn_TopWhilePlaying.IsChecked == true)
            {
                if (IsMediaPlaying == true)
                {
                    Window parent = Window.GetWindow(this);
                    parent.Topmost = true;
                }
                else
                {
                    Window parent = Window.GetWindow(this);
                    parent.Topmost = false;
                }
            }
            else if (rdobtn_LetUserPick.IsChecked == true)
            {
                Window parent = Window.GetWindow(this);
                parent.Topmost = false;
            }
        }
        private void mePlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            IsMediaPlaying = false;
            RoutedEventArgs newEventArgs1 = new RoutedEventArgs(Button.ClickEvent);  //Go to next
            button1.RaiseEvent(newEventArgs1);
        }
        private void mePlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            IsMediaPlaying = false;
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Button.ClickEvent);  //Go to next
            button1.RaiseEvent(newEventArgs);
        }
        private void play_Click(object sender, RoutedEventArgs e)
        {
            PlayMedia();
        }
        private void pause_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.LoadedBehavior = MediaState.Pause;
            IsMediaPlaying = false;
        }
        private void listbox4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayMedia();
        }
