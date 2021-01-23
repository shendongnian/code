    public partial class frmToDoDetails : Form
    {
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public bool EditMode { get; set; }
        public frmToDoDetails()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TaskTitle = txtTitle.Text;
            Description = txtDesc.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void frmToDoDetails_Load(object sender, EventArgs e)
        {
            if (EditMode)
            {
                txtTitle.Text = TaskTitle;
                txtDesc.Text = Description;
            }
            else {
                txtTitle.Text = string.Empty;
                txtDesc.Text = string.Empty;            
            }
            txtTitle.Focus();
        }
    }
