    private Warning _colWarning = new Warning();
    public Warning ColWarning {
        get { return _colWarning; }
        set {
            _colWarning = value;
            //  ...or whatever you're doing to raise PropertyChanged
            OnPropertyChanged("ColWarning");
        }
    }
