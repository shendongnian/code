      public partial class AddText : Form
      {
        private Form1 _form1;
    
        public AddText(Form1 form1)
        {
          InitializeComponent();
          _form1 = form1;
        }
    
        private void AddText_Load(object sender, EventArgs e)
        {
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          _form1.SetText(textBox1.Text);
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
          this.Close();
        }
      }
