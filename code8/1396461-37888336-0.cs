    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                MessageBox.Show("Hello");
            }
        }
