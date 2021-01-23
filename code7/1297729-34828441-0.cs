    static Library l;
            static WMPLib.WindowsMediaPlayer song; 
            public static void playTrack(int t)
            {
                l = new Library();
                song = new WMPLib.WindowsMediaPlayer();
                song.URL = l.myLibrary[t].Patch;
                song.controls.play();
            }
