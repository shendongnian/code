    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
        }
        private Form2 _frm2;
        private void Form1_Load(object sender, EventArgs e)
        {
            _frm2 = new Form2();
            _frm2.MdiParent = this;
            _frm2.PropertyChanged += _frm2_PropertyChanged;
            _frm2.Show();
        }
        void _frm2_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Visible")
            {
                showToolStripMenuItem.Checked = _frm2.Visible;
            }
        }
        private void showToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (_frm2 != null)
                _frm2.Visible = menuItem.Checked;
        }
    }
