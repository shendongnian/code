     public partial class Form1 : Form
        {
            public Form1()
            {
                Form2.lblvar = lblvarinform1;
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                lblvarinform1.Text = txtdatepicker.Text;
                Form2.lblvar.Text = lblvarinform1.Text;
            }
        }
