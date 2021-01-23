    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();
            
            // Get the data and mark points.
            double dataPoints[] = GetDataPoints();
            Point markPoints[] = GetMarkPoints();
            
            // Plot the data.
            line.Plot(dataPoints);
            
            // Plot the markers.
            markers.Plot(markPoints);
        }
    }
