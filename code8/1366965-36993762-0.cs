    public partial class Form1 : Form
    {
        private FormSettings frmSettings1 = new FormSettings();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = frmSettings1.FormText;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmSettings1.FormText = textBox1.Text;
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSettings1.Save();
        }
    }
    //Application settings wrapper class
    sealed class FormSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        public String FormText
        {
            get { return (String)this["FormText"]; }
            set { this["FormText"] = value; }
        }
    }
