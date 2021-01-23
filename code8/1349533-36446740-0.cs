    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;
            form2 = new Form2();
            form2.Show();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form2.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
