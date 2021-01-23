      public partial class Form2 : Form
        {
            Form1 frm;
            public Form2(Form1 frm)
            {
                InitializeComponent();
                this.frm = frm;
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
    
            }
    
            private void btnOk_Click(object sender, EventArgs e)
            {
                if (textBox1.Text == "12345")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    frm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosingFalse);
                   frm.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    frm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosingTrue);
                
                }
            }
    
            public void Form1_FormClosingTrue(object sender, FormClosingEventArgs e)
            {
                e.Cancel = true;
            }
            public void Form1_FormClosingFalse(object sender, FormClosingEventArgs e)
            {
                e.Cancel = false ;
            }
        }
