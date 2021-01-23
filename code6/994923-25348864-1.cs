        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ipSettings = new IPSettings();
            textBoxIpAddress1.DataBindings.Add("Text", ipSettings, "IPAddress");
        }
        private IPSettings ipSettings;
        private void buttonOpenDialog_Click(object sender, EventArgs e)
        {
            new Form2(ipSettings).ShowDialog();
        }
    }
