    private static int volume = 40;
    private void volume_changer(int vol)
    {
        volume = vol;
    }
    private void preview_Player_MediaChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerMediaChangedEventArgs e)
    {
        preview_Player.Audio.Volume = volume;
    }
