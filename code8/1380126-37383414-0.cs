    public partial class baseForm : Form
    {
        public baseForm()
        {
            InitializeComponent();
        }
    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F3))
            {
                //Show search form
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
