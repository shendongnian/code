    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using(var form = new Form2("192.168.1.1"))
            {
                form.ShowDialog();
            }
        }
    }
