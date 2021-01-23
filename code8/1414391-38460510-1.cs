    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void buttonLaunchForm_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.LauncherForm = this;
    
            form2.Show();
        }
    
    }
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        public Form1 LauncherForm { set; get; }
    
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // do your normal work then:
           
            LauncherForm.RefreshFormData();
        }
    }
