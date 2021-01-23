    int volume { get; set; }
    
    public Constructor(){
        InitializeComponent();
        myVlcControl.VideoOutChanged += myVlcControl_VideoOutChanged;
    }
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        this.volume = (int)numericUpDown1.Value;
        myVlcControl.Audio.Volume = volume;
    }
    void vlcPlayer_VideoOutChanged(object sender, VlcMediaPlayerVideoOutChangedEventArgs e)
    {
        myVlcControl.Audio.Volume = volume;
    }
