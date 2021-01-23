    public class MainViewModel
    {
        public MainViewModel()
        {
            Model = new PlotModel
            {
                Title = "Colouring example"
            };
            var series = new ThreeColorLineSeries();
            // Random data
            var rand = new Random();
            var x = 0;
            while (x < 50)
            {
                series.Points.Add(new DataPoint(x, rand.Next(0, 20)));
                x+=1;
            }
            // Colour limits
            series.LimitHi = 14;
            series.LimitLo = 7;
            // Colours
            series.Color = OxyColor.FromRgb(255,0,0);
            series.ColorHi = OxyColor.FromRgb(0,255,0);
            series.ColorLo = OxyColor.FromRgb(0,0,255);
            Model.Series.Add(series);
        }
        public PlotModel Model { get; set; }
    }
