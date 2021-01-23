    public void ZoomFunction(PlotModel PlotModel)
    {
        foreach (var axes in PlotModel.Axes)
        {
            axes.Reset();
        }
        PlotModel.InvalidatePlot(true);
    }
