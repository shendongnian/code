    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        string greetme;
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            greetme = textbox1.text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello {0}", greetme);
        } 
    }
