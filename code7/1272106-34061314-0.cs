    public virtual PlotModel CreatePlotModel()
    {
        var model = new OxyPlot.PlotModel();
        LineSeries LS= new LineSeries();
        Random rnd = new Random();
        for (int i=0; i<10; i++)
        {
            LS.Points.Add(new DataPoint(i,rnd.Next(1,100)));
        }
        model.Series.Add(LS);
        model.InvalidatePlot(false);
        return model;
    }
