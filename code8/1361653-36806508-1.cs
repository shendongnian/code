    namespace DoubleForms
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2();
                frm2.Updated += (se,ev)=> textBox1.Text = "Test"; // update textbox
                frm2.Show();
            }
        }
    }
