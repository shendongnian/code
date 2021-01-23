    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnOne_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnOne.Text;
        }
    }
