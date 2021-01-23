    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Shift | Keys.A))
            {
    
            }
            else if (keyData == (Keys.Control | Keys.I))
            {
    
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
