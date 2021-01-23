    public class MyViewModel
    {
        public PlotModel MyModel { get; set; }
        public MyViewModel()
        {
            PieSeries pieSeries = new PieSeries();
            pieSeries.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            pieSeries.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Oceania", 350) { IsExploded = true });
            MyModel = new PlotModel();
            MyModel.Series.Add(pieSeries);
        }
    }
