     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Boolean boy;
            Boolean girl;
            if (boy.Equals(true))
            {
                MessageBox.Show(textBox1.Text + " is among the most popular boy names!");
            }
            if (boy.Equals(false))
            {
                MessageBox.Show(textBox1.Text + " is not among the most popular boy names.");
            }
            if (girl.Equals(true))
            {
                MessageBox.Show(textBox2.Text + " is among the most popular girl names!");
            }
            if (girl.Equals(false))
            {
                MessageBox.Show(textBox2.Text + " is not among the most popular girl names.");
            }
        }
    }
