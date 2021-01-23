    class Form1 : Form
    {
        TextBox[] txtbx;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(textBox1.Text);
            txtbx = new TextBox[y];  // Now this references the class member
            for (int i = 0; i < y; i++)
            ... etc.
        }
    }
