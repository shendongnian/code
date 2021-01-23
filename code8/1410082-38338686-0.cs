    public class MyViewModel : BaseViewModel
    {
        public MyViewModel()
        {
            int counter = 0;
            while (counter < 10)
            {
                GraphPlots.Add(GeneratePlotPoints());
                counter++;
            }
        }
    
        PlotModel GeneratePlotPoints()
        {
            var mo = new PlotModel();
            var s1 = new LineSeries()
            {
                Color = OxyColors.SkyBlue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.SkyBlue,
                MarkerStrokeThickness = 1.5
            };
            s1.Points.Add(new DataPoint(0, 10));
            s1.Points.Add(new DataPoint(10, 40));
            s1.Points.Add(new DataPoint(40, 20));
            s1.Points.Add(new DataPoint(60, 30));
            mo.Series.Add(s1);
            return mo;
        }
    
        ObservableCollection<PlotModel> _graphPlots = new ObservableCollection<PlotModel>();
        public ObservableCollection<PlotModel> GraphPlots
        {
            get { return _graphPlots; }
            set { SetProperty(ref _graphPlots, value); }
        }
    }
