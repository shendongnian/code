    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            MyClass me = new MyClass();
            //you can use me[index] = value  for accessing the index of your indexer
            for (int i = 0; i < 3; i++)
            {
                MessageBox.Show(me[i]);
            }
        }
    }
    
    class MyClass
    {
        string[] name = { "Ali", "Reza", "Ahmad" };
        public string this[int index]
        {
            get { return name[index]; }
            set { name[index] = value; }
        }
    }
