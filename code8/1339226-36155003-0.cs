    public partial class _Default : Page
    {
        [Inject]
        public IMetricService metricService {get; set}
        protected void Page_Load(object sender, EventArgs e)
        {
            metricService.GetAllMetrics();
        }
    }
