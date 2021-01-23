    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void _openFormTwoButton_Click(object sender, EventArgs e)
        {
            MySingletonClass.Instance.MySharedProperty = textBox1.Text;
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
