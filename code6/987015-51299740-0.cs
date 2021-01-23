    public class MyForm
    {
        public MyForm()
        {
            InitializeComponent();
            listView1.EnsureVisible(8);  // will not work !!!
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            listView1.EnsureVisible(8);  // Works fine
        }
    }
