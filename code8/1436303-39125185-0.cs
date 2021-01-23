    private bool _hasLink;      
    public bool hasLink 
            {
                get { return _hasLink; }
                set
                {
                    _hasLink= value;
                    OnPropertyChanged();
                }
            }
