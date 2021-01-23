    private PlotModel _plot;
    public PlotModel PlotModel
    {
        get { return _plot; }
        set
        {
            _plot = value;
            OnPropertyChanged(); // <=== update here
        }
    }
