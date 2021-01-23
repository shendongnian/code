    public class CDFViewModel
    {
        public ObservableCollection<CDFPlot> CDFPlotCollection { get; set; }
        public CDFViewModel()
        {
            Random r = new Random();
            CDFPlotCollection = new ObservableCollection<CDFPlot>();
            CDFPlotCollection.Add(new CDFPlot(r, 0));
            CDFPlotCollection.Add(new CDFPlot(r, 2));
        }
    }
