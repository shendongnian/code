    public partial class Form1 : Form
        {
            public string Value;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.Value = textBox1.Text;
                textBox2.Text = this.Value;
            }
        }
