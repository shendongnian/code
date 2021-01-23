    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            MyClass me = new MyClass();
            MessageBox.Show(me[0]);
            me[1] = "Masoud";
            MessageBox.Show(me[1]);
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
