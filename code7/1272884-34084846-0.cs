     private void GetMediaFiles()
        {
            FilePath = Application.StartupPath + "\\Videos\\";
            FileCount = Directory.GetFiles(FilePath).Length;
            Files = Directory.GetFiles(FilePath);
            playlist = axWMPlayer.playlistCollection.newPlaylist("MyPlaylist");
            for (int Count = 0; Count < FileCount; Count++)
            {
                media = axWMPlayer.newMedia(Files[Count]);
                playlist.appendItem(media);
            }
            RunMedia();
        }
        private void RunMedia()
        {
            try 
            {
                if (playlist.count > 0)
                {
                    axWMPlayer.BringToFront();
                    axWMPlayer.currentPlaylist = playlist;
                    axWMPlayer.Ctlcontrols.play();
                }
                else
                {
                    pbDefaultImage.BringToFront();
                }
            }
