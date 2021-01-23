    class MyObject
    {
        string name;
        public MyObject()
        { }
        public string Name
        {
            get { return name;}
            set { name = value; }
        }
    }
    public partial class Form1 : Form
    {
        MyObject obj = new MyObject();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            obj.Name = "Lucas";
            textBox1.DataBindings.Add("Text", obj, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = obj.Name;
        }
    }
