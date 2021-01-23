    vlcControl.TimeChanged += vlcControl_VideoOutChanged;
    private void vlcControl_VideoOutChanged(object sender, VlcMediaPlayerTimeChangedEventArgs e)
    {
        vlcControl.Audio.Volume = volume;
    }
