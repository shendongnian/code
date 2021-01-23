    public MainViewModel()
    {
        CurrentMediaElement = new MediaElementViewModel();
    }
    private MediaElementViewModel _currentMediaElement;
    public MediaElementViewModel CurrentMediaElement
    {
        get { return _currentMediaElement; }
        set
        {
            _currentMediaElement = value;
            RaisePropertyChanged("CurrentMediaElement");
        }
    }
    private RelayCommand _setSourceCommand;
    public ICommand SetSourceCommand
    {
        get
        {
            return _setSourceCommand ??
                    (_setSourceCommand = new RelayCommand(SetSourceExecute));
        }
    }
    private RelayCommand _playCommand;
    public ICommand PlayCommand
    {
        get
        {
            return _playCommand ??
                    (_playCommand = new RelayCommand(PlayExecute));
        }
    }
    private RelayCommand _stopCommand;
    public ICommand StopCommand
    {
        get
        {
            return _stopCommand ??
                    (_stopCommand = new RelayCommand(StopExecute));
        }
    }
    private RelayCommand _focusCommand;
    public ICommand FocusCommand
    {
        get
        {
            return _focusCommand ??
                (_focusCommand = new RelayCommand(FocusExecute));
        }
    }
    /// <summary>
    /// Invoked whenever focusing media element;
    /// </summary>
    private void FocusExecute()
    {
        bool isFocused = this.CurrentMediaElement.Focus();
    }
    /// <summary>
    /// Invoked whenever setting a media source.
    /// </summary>
    private void SetSourceExecute()
    {
        // Assume the media file location is Debug/bin/Resources/
        this.CurrentMediaElement.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\media.mp3");
    }
    /// <summary>
    /// Invoked whenever playing media.
    /// </summary>
    private void PlayExecute()
    {
        this.CurrentMediaElement.Play();
    }
    /// <summary>
    /// Invoked whenerver stopping media.
    /// </summary>
    private void StopExecute()
    {
        this.CurrentMediaElement.Stop();
    }
