    private ObservableCollection<Substance> _substances;
    public static ObservableCollection<Substance> Substances
    {
        get
        {
            if (_substances == null) {
               GetSubstanceDataAsync();
            }
            return _substances;
        }
        set
        {
            _substances = value;
        }
    }
    private async void GetSubstanceDataAsync(){
        Substances = await Substance.GetSubstanceDataAsync();
    }
