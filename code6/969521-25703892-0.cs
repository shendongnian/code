    private object PlotXYAppend (Chart chart, Series dataSeries, double x, double y)
    {
        return chart.Invoke(new PlotXYDelegate(dataSeries.Points.AddXY), new Object[] { x, y });    
    }
        
    public IEnumerable<object> PlotXYPass (double[] X, double[] Y)
    {
        return X.Zip<double, double, object>(Y, (x, y) => this.PlotXYAppend(this.chart, this.dataSeries, x, y));
    }
        
