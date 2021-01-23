    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form2 f2 = new Form2();
            f2.Show();
            f2.Enabled = false;
            button1.Click += delegate { f2.Enabled = true; };
        }
    }
