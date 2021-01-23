        public partial class Form1 : Form
    {
        private int x = 10;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.XValue = x;
            form2.Show();
        }
    }
