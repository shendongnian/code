    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                label1.Text = frm.MyNewText;
            }
        }
    }
