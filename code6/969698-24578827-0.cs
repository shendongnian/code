    public partial class ConfigureForm : Form
    {
        private From1 mainForm = null;
        public ConfigureForm()
        {
            InitializeComponent();
        }
        
        public ConfigureForm(Form callingForm):this()
        {
            mainForm = callingForm as Form1;
        }
        private void Portal2HammerButtonEnable_Click(object sender, EventArgs e)
        {
            mainForm.Portal2HammerButton.Enabled = true;
        }
    }
