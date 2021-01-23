    public class Sounds
    {
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
    
        private void PlayFile(String url)
        {
            Player.URL = url;
            Player.controls.play();
        }
    }
