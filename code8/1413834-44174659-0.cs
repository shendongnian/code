    public partial class MainForm : Form , IMainView
    {
        [Resolve]
        public IMainControl mainControl;
        public MainForm()
        {
            InitializeComponent();
        }
        public bool ShowAsDialog()
        {
            throw new NotImplementedException();
        }
        private void openChildFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainControl.OnOpenChildForm();
        }
    }
