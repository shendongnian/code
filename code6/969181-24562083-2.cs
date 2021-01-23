    using System.Linq;
    double[] X = { 1, 2, 3, 4, 5, 6 };
    double[] Y = { 1, 2, 3, 4, 5, 6 };
    Chart someChart;
    Series someDataSeries;
    private void PlotXYPass(double[] X, double[] Y)
    {
        X.Zip(Y, (x, y) => new { x, y }).ToList()
            .ForEach(
                p => PlotXYAppend(someChart, someDataSeries, p.x, p.y)
            );
    }
