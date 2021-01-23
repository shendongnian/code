    UpdatePlaylistMessageExtra UpdatePlaylistMessageExtra;
            if (MessageService.TryParseMessage(e.Data, out UpdatePlaylistMessageExtra))
            {
                if (playbackList != null)
                {
                    playbackList = null;
                    CreatePlaybackList(UpdatePlaylistMessageExtra.Songs); //Recreate to start from start and not cached stream
                    Debug.WriteLine("Playbacklist rebinded in BG");
                    BackgroundMediaPlayer.Current.AutoPlay = true;
                }
                return;
            }
