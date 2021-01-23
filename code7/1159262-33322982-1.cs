    public MediaElementViewModel()
    {
        Volume = 0.5;
    }
    private Uri _source;
    public Uri Source
    {
        get { return _source; }
        set
        {
            _source = value;
            RaisePropertyChanged("Source");
        }
    }
    private double _volume;
    public double Volume
    {
        get { return _volume; }
        set
        {
            _volume = value;
            RaisePropertyChanged("Volume");
        }
    }
    public Action Play { get; set; }
    public Action Stop { get; set; }
    public Func<bool> Focus { get; set; }
