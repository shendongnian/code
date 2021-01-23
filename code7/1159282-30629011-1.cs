    public partial class secondForm : Form
    {
        public Form1 form1 { get; set;}
        public secondForm(Form1 f)
        {
            form1 = f;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
            form1.loadwebpage("http://www.google.com");
        }
    }
