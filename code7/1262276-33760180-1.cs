    public partial class Form2 : Form
        {
            Label x;
            public Form2(Label y)
            {
                InitializeComponent();
                x = y;
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                x.Text = textBox1.Text;
            }
        }
