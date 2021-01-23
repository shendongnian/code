    /// <summary>
    /// Gets or sets the ChartPlotModel.
    /// </summary>
    public PlotModel ChartPlotModel
    {
        get
        {
            return this.chartPlotModel;
        }
        set
        {
            if (this.chartPlotModel != value)
            {
                this.chartPlotModel = value;
                this.RaisePropertyChanged("ChartPlotModel");
            }
        }
    }
