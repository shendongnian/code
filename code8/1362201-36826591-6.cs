    public class Sounds
    {
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
    
        private void PlayFile(String url)
        {
            player.URL = url;
            player.controls.play();
        }
    }
