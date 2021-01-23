    private List<LineViewModel> _lineViewModels;
    public List<LineViewModel> LineViewModels
    {
        get { return _lineViewModels; }
        set
        {
            if (value == _lineViewModels) return;
            _lineViewModels = value;
            PropertyChanged(this, new PropertyChangedEventArgs("LineViewModels"));
        }
    }
