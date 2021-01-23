     public partial class Form3 : Form
    {
        public Form FormName { get; set; }
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form fromName)
        {
            FormName = fromName;
            InitializeComponent();
        }
        private void BackToFrom(object sender, EventArgs e)
        {
            FormName.Show();
            this.Hide();
        }
    }  
