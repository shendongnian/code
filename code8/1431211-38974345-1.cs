    public partial class Form1 : Form
    {
        private void EditBtn_Click(object sender, EventArgs e)
        {
            // listBox1 is already set on the designer
            Form2 frm = new Form2(textBox1.Text, listBox1);
            frm.ShowDialog();
            frm.Show();
        }
    }
    public partial class Form2 : Form
    {
        private ListBox _listBox1;
        public Form2(string value, ListBox listBox1)
        {
            InitializeComponent();
            textBox1.Text = value;
            _listBox1 = listBox1;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _listBox1.Items.Add("returned Value");
        }
    }
