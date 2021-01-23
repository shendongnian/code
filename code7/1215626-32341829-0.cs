    public partial class Form1 : Form
    {
        private class Foo
        {
            public string Title { get; set; }
            public int DontShowMe { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Foo foo = new Foo() { Title = "Hello", DontShowMe = 42 };
            ListViewItem item = new ListViewItem() { Text = foo.Title, Tag = foo };
            listView1.Items.Add(item);
        }
    }
