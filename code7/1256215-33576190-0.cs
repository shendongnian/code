    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();  //<-- This line changed.
            //With using ShowDialog(), the code pauses here until frm2 is closed
            //and then resumes on the next line.
            textBox1.Text = frm2.p;
    
        }
    }
