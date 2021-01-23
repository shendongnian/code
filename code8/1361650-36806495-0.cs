        public partial class Form1 : Form
        {
            // NEW CODE
            public string TextBoxText 
            { 
                get { return this.textBox1.Text; }
                set { this.textBox1.Text = value; }
             }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2();
                frm2.Show();
            }
        }
    }
