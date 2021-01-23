    public partial class frmVerify : Form
    {
        public frmVerify()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && this.ActiveControl is Button)
            {
                return true; // suppress the keystroke
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        // ... more code ...
    }
