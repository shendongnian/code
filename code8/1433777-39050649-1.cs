    public partial class Form1 : Form
    {
        private Class1 _class1;
        public Form1()
        {
            InitializeComponent();
            _class1 = new Class1(); // logic class instance
            _class1.AddItem += (sender, e) =>
            {
                Invoke((MethodInvoker)(() => _class1.BindingList.Add(e.Item)));
            };
            listBox1.DataSource = _class1.BindingList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _class1.Add();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _class1.Remove();
        }
    }
