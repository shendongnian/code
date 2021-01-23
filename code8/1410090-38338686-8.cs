    public class MyViewModel : BaseViewModel
    {
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
    
        List<PlotModel> GenerateGraph()
        {
            var graphPlots = new List<PlotModel>();
            int counter = 0;
    
            while (counter < 10)
            {
                graphPlots.Add(GeneratePlotPoints());
                counter++;
            }
    
            return graphPlots;
        }
    
        public List<PlotModel> GraphPlots => GenerateGraph();
    }
