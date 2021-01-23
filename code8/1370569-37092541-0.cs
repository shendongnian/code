    public partial class Form1 : Form
    {
        public int x;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            x = 5;
            MessageBox.Show(x.ToString());
        }
    }
