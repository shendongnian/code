    public class CDFPlot : ObservableCollection<Point>
    {
        public CDFPlot(Random r, double delta)
        {
            for (int i = 0; i < 50; i++)
                Add(new Point { X = i, Y = delta+r.NextDouble() });
        }
    }
