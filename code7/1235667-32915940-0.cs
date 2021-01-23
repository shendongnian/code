    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Some other logic for OK button
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Some other logic for Cancel button
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }        
