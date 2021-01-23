    namespace stackoverflow
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                label1.Text = "Not clicked!";
            }
            int number = 0;
            private void label1_Click(object sender, EventArgs e)
            {
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                label1.Text = "Clicked button 1.";
                number = 1;
            }
            private void button2_Click(object sender, EventArgs e)
            {
                label1.Text = "Clicked button 2.";
                number = 2;
            }
        }
    }
