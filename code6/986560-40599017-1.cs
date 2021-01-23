    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
            _thread = new ThreadController();
        }
        
        private readonly ThreadController _thread;
        private void btn_start_Click(object sender, EventArgs e)
        {
            var mst = new Mouse_Tracking();
            _thread.Start(mst.run);
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            _thread.Stop();
        }
    }
