    public void AutoZoom()
    {
        double max;
        double min;
        // some code to determine the max/min values for the y-axis
        // ...
        PlotModel.Axes[1].Reset(); //Reset the axis to clear ViewMinimum and ViewMaximum
        
        ((LinearAxis)PlotModel.Axes[1]).Maximum = max;
        ((LinearAxis)PlotModel.Axes[1]).Minimum = min;
        PlotModel.InvalidatePlot(true);
    }
