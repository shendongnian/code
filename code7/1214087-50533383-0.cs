    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private ObservableCollection<EnumeradorWCFModel> _tiposCarga;
    public ObservableCollection<EnumeradorWCFModel> TiposCarga
    {
        get { return _tiposCarga; }
        set
        {
            if (_tiposCarga != value)
            {
                _tiposCarga = value;
                OnPropertyChanged(nameof(TiposCarga));
            }
        }
    }
