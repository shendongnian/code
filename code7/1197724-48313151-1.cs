    public bool Complete { get; set; }
    public string TickboxImageSource
    {
        get
        {
            return Complete ? "TickboxTicked.png" : "TickboxEmpty.png";
        }
    }
    
    public int TickedOpacity
    {
        get
        {
            return Complete ? 1 : 0;
        }
    }
    
    public int UntickedOpacity
    {
        get
        {
            return Complete ? 0 : 1;
        }
    }
    
    ...
    public async void OnCompletePressed(object source)
    {
        Complete = !Complete;
        OnPropertyChanged("Complete");
        OnPropertyChanged("TickedOpacity");
        OnPropertyChanged("UntickedOpacity");
    }
