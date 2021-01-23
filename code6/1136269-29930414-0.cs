    public partial class myForm : Form
    {
        public myForm()
        {
            InitializeComponent();
            DialogResult dialogOpen = MessageBox.Show("Use the navigation menu to get started.", "Welcome!", MessageBoxButtons.OK);
        }
    }
