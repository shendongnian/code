    public partial class frmBase: Form
    {
        public frmBase()
        {
            InitializeComponent();
        }
    
        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }           
    }
