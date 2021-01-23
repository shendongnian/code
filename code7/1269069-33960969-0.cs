    public partial class Form1 : Form
    {
        UserControl1 UC1;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (UC1 == null)
            {
                UC1 = new UserControl1(textBox1);
            }
            Controls.Add(UC1);
            UC1.Visible = true;
        }
    }
