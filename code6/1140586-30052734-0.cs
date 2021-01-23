    public partial class MainForm : Form
    {
        private ToolStripDropDown dropDown = new ToolStripDropDown();
        public MainForm()
        {
            InitializeComponent();
            dropDown.Items.Add(new ToolStripControlHost(new ToolTipUserControl() { Size = new Size(200, 200) }));
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            dropDown.Show(MousePosition);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            dropDown.Hide();
        }
    }
