    public partial class GraphForm : Form
    {
        public string GraphTitle { get; set; }
        public List<int> GraphData { get; set; } 
        public GraphForm(string graphTitle, List<int> graphData )
        {
            InitializeComponent();
            GraphTitle = graphTitle;
            GraphData = graphData;
        }
        private void GraphForm_Load(object sender, EventArgs e)
        {
            // Do the plotting here.
        }
    }
