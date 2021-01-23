    public partial class formA : Form
    {
        public formA()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            formB b = new formB();
            b.owner = this;
            b.ShowDialog();
        }
    }
