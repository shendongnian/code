    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
            form2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2.button1_Click(null, null);
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Log");
            listView1.Items.Add(new ListViewItem(new string[] { "go2" }));
        }
    }
