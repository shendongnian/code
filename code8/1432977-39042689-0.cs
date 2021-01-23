    public partial class Form2 : Form
        {
            Form1 a;
            public Form2(Form1 b)
            {
                a = b;
                InitializeComponent();
    
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string g;
                g = textBox1.Text;
    
           
                a.set(g);
                this.Close();
            }
        }
